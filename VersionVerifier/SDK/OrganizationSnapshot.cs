namespace Cinteros.Xrm.VersionVerifier.SDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using Cinteros.Xrm.VersionVerifier.Utils;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Client;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;

    public class OrganizationSnapshot
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSnapshot"/> class.
        /// </summary>
        public OrganizationSnapshot()
        {
            this.Solutions = new Solution[0];
            this.Assemblies = new PluginAssembly[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSnapshot"/> class.
        /// </summary>
        /// <param name="connectionDetail">Object holding connection details to given organization.</param>
        /// <param name="reference">Instance of the <see cref="OrganizationSnapshot"/> class, serving as refenece. 
        /// Only these solutions and assemblies will be included, that are already present in the reference.</param>
        public OrganizationSnapshot(ConnectionDetail connectionDetail, OrganizationSnapshot reference)
        {
            Solution[] solutions = null;
            PluginAssembly[] assemblies = null;
            DataCollection<Entity> entities = null;

            var organizationService = new OrganizationService(CrmConnection.Parse(connectionDetail.GetOrganizationCrmConnectionString()));

            entities = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities;
            solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
            solutions = solutions.Where(x => reference.Solutions.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<Solution>();

            entities = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities;
            assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
            assemblies = assemblies.Where(x => reference.Assemblies.Where(y => y.FriendlyName == x.FriendlyName).Count() > 0).ToArray<PluginAssembly>();

            this.ConnectionDetail = connectionDetail;
            this.Solutions = solutions;
            this.Assemblies = assemblies;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSnapshot"/> class.
        /// </summary>
        /// <param name="connectionDetail">Object holding connection details to given organization.</param>
        public OrganizationSnapshot(ConnectionDetail connectionDetail)
        {
            var organizationService = new OrganizationService(CrmConnection.Parse(connectionDetail.GetOrganizationCrmConnectionString()));

            this.ConnectionDetail = connectionDetail;
            this.Solutions = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities.Select(x => new Solution(x)).ToArray<Solution>();
            this.Assemblies = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities.Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSnapshot"/> class.
        /// </summary>
        /// <param name="fileName">Location of XML file from which instance of the <see cref="OrganizationSnapshot"/> class will be constructed.</param>
        public OrganizationSnapshot(string fileName)
        {
            var document = new XmlDocument();
            document.Load(fileName);

            var solutions = new List<Solution>();
            var assemblies = new List<PluginAssembly>();

            this.Solutions = solutions.ToArray();
            this.Assemblies = assemblies.ToArray();

            var errorCount = 0;

            foreach (XmlElement element in document.DocumentElement.ChildNodes)
            {
                if (element.Name == Constants.U_SOLUTIONS.ToLower())
                {
                    foreach (XmlElement solution in element.ChildNodes)
                    {
                        try
                        {
                            var item = new Solution
                            {
                                Version = new Version(solution.Attributes["version"].Value),
                                UniqueName = solution.Attributes["unique-name"].Value,
                                FriendlyName = solution.Attributes["friendly-name"].Value
                            };

                            solutions.Add(item);
                        }
                        catch (NullReferenceException)
                        {
                            errorCount++;
                        }
                    }

                    this.Solutions = solutions.ToArray();
                }

                if (element.Name == Constants.U_ASSEMBLIES.ToLower())
                {
                    foreach (XmlElement assembly in element.ChildNodes)
                    {
                        try
                        {
                            var item = new PluginAssembly()
                            {
                                Version = new Version(assembly.Attributes["version"].Value),
                                FriendlyName = assembly.Attributes["friendly-name"].Value
                            };

                            assemblies.Add(item);
                        }
                        catch (NullReferenceException)
                        {
                            errorCount++;
                        }
                    }

                    this.Assemblies = assemblies.ToArray();
                }

                if (errorCount != 0)
                {
                    MessageBox.Show(string.Format("Reference file was not fully loaded. \nNumber of elements failed: {0}", errorCount), "File import error"); 
                }
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets array of assemblies available in the organization
        /// </summary>
        public PluginAssembly[] Assemblies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets connection detail for the organization.
        /// </summary>
        public ConnectionDetail ConnectionDetail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets array of solutions available in the organization.
        /// </summary>
        public Solution[] Solutions
        {
            get;
            set;
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Replaces text representation of <see cref="OrganizationSnapshot"/> class of name of organization it connected.
        /// </summary>
        /// <returns>Text representation of <see cref="OrganizationSnapshot"/> class.</returns>
        public override string ToString()
        {
            if (this.ConnectionDetail != null && this.ConnectionDetail.OrganizationFriendlyName != null && !string.IsNullOrEmpty(this.ConnectionDetail.OrganizationFriendlyName))
            {
                return this.ConnectionDetail.OrganizationFriendlyName;
            }
            else
            {
                return base.ToString();
            }
        }

        public XmlDocument ToXml()
        {
            var document = new XmlDocument();

            document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", "yes"));
            document.AppendChild(document.CreateComment("Reference snapshot"));

            var root = document.CreateElement("snapshot");
            document.AppendChild(root);

            XmlElement element;
            XmlAttribute attribute;

            var solutions = document.CreateElement("solutions");
            root.AppendChild(solutions);

            foreach (var solution in this.Solutions)
            {
                element = document.CreateElement("solution");

                attribute = document.CreateAttribute("unique-name");
                attribute.Value = solution.UniqueName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute("friendly-name");
                attribute.Value = solution.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute("version");
                attribute.Value = solution.Version.ToString();
                element.Attributes.Append(attribute);

                solutions.AppendChild(element);
            }

            var assemblies = document.CreateElement("assemblies");
            root.AppendChild(assemblies);

            foreach (var assembly in this.Assemblies)
            {
                element = document.CreateElement("assembly");

                attribute = document.CreateAttribute("friendly-name");
                attribute.Value = assembly.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute("version");
                attribute.Value = assembly.Version.ToString();
                element.Attributes.Append(attribute);

                assemblies.AppendChild(element);
            }

            return document;
        }

        #endregion Public Methods
    }
}