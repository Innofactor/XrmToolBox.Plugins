namespace Cinteros.Xrm.SDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Cinteros.Xrm.Utils;
    using McTools.Xrm.Connection;
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
        /// <param name="reference">
        /// Instance of the <see cref="OrganizationSnapshot"/> class, serving as refenece. Only
        /// these solutions and assemblies will be included, that are already present in the reference.
        /// </param>
        public OrganizationSnapshot(ConnectionDetail connectionDetail, OrganizationSnapshot reference)
        {
            Solution[] solutions = null;
            PluginAssembly[] assemblies = null;
            DataCollection<Entity> entities = null;

            var organizationService = connectionDetail.GetOrganizationService();

            try
            {
                entities = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities;
                solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
                solutions = solutions.Where(x => reference.Solutions.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<Solution>();

                entities = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities;
                assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
                assemblies = assemblies.Where(x => reference.Assemblies.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<PluginAssembly>();
            }
            catch (Exception ex)
            {
                // Hiding exceptions
            }

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
            var organizationService = connectionDetail.GetOrganizationService();

            this.ConnectionDetail = connectionDetail;
            this.Solutions = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities.Select(x => new Solution(x)).ToArray<Solution>();
            this.Assemblies = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities.Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSnapshot"/> class.
        /// </summary>
        /// <param name="fileName">
        /// Location of XML file from which instance of the <see cref="OrganizationSnapshot"/> class
        /// will be constructed.
        /// </param>
        public OrganizationSnapshot(string fileName)
        {
            var document = new XmlDocument();
            document.Load(fileName);

            this.Load(document);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSnapshot"/> class.
        /// </summary>
        /// <param name="document">
        /// XML document from which instance of the <see cref="OrganizationSnapshot"/> class will be constructed.
        /// </param>
        public OrganizationSnapshot(XmlDocument document)
        {
            this.Load(document);
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
        /// Replaces text representation of <see cref="OrganizationSnapshot"/> class of name of
        /// organization it connected.
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

            var solutions = document.CreateElement(Constants.Xml.SOLUTIONS);
            root.AppendChild(solutions);

            foreach (var solution in this.Solutions)
            {
                element = document.CreateElement(Constants.Xml.SOLUTION);

                attribute = document.CreateAttribute(Constants.Xml.UNIQUE_NAME);
                attribute.Value = solution.UniqueName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.FRIENDLY_NAME);
                attribute.Value = solution.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.VERSION);
                attribute.Value = solution.Version.ToString();
                element.Attributes.Append(attribute);

                solutions.AppendChild(element);
            }

            var assemblies = document.CreateElement(Constants.Xml.ASSEMBLIES);
            root.AppendChild(assemblies);

            foreach (var assembly in this.Assemblies)
            {
                element = document.CreateElement(Constants.Xml.ASSEMBLY);

                attribute = document.CreateAttribute(Constants.Xml.FRIENDLY_NAME);
                attribute.Value = assembly.FriendlyName;
                element.Attributes.Append(attribute);

                attribute = document.CreateAttribute(Constants.Xml.VERSION);
                attribute.Value = assembly.Version.ToString();
                element.Attributes.Append(attribute);

                assemblies.AppendChild(element);
            }

            return document;
        }

        #endregion Public Methods

        #region Private Methods

        private void Load(XmlDocument document)
        {
            var solutions = new List<Solution>();
            var assemblies = new List<PluginAssembly>();

            this.Solutions = solutions.ToArray();
            this.Assemblies = assemblies.ToArray();

            foreach (XmlElement element in document.DocumentElement.ChildNodes)
            {
                if (element.Name == Constants.Xml.SOLUTIONS)
                {
                    foreach (XmlElement solution in element.ChildNodes)
                    {
                        try
                        {
                            var item = new Solution
                            {
                                Version = new Version(solution.Attributes[Constants.Xml.VERSION].Value),
                                UniqueName = solution.Attributes[Constants.Xml.UNIQUE_NAME].Value,
                                FriendlyName = solution.Attributes[Constants.Xml.FRIENDLY_NAME].Value
                            };

                            solutions.Add(item);
                        }
                        catch (NullReferenceException)
                        {
                            // Hiding import errors
                        }
                    }

                    this.Solutions = solutions.ToArray();
                }

                if (element.Name == Constants.Xml.ASSEMBLIES)
                {
                    foreach (XmlElement assembly in element.ChildNodes)
                    {
                        try
                        {
                            var item = new PluginAssembly()
                            {
                                Version = new Version(assembly.Attributes[Constants.Xml.VERSION].Value),
                                FriendlyName = assembly.Attributes[Constants.Xml.FRIENDLY_NAME].Value,
                                UniqueName = assembly.Attributes[Constants.Xml.UNIQUE_NAME].Value
                            };

                            assemblies.Add(item);
                        }
                        catch (NullReferenceException)
                        {
                            // Hiding import errors
                        }
                    }

                    this.Assemblies = assemblies.ToArray();
                }
            }
        }

        #endregion Private Methods
    }
}