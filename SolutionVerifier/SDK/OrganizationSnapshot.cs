namespace Cinteros.Xrm.SolutionVerifier.SDK
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Cinteros.Xrm.SolutionVerifier.Utils;
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
        /// <param name="connectionDetail"></param>
        /// <param name="reference"></param>
        public OrganizationSnapshot(ConnectionDetail connectionDetail, OrganizationSnapshot reference)
        {
            Solution[] solutions = null;
            PluginAssembly[] assemblies = null;
            DataCollection<Entity> entities = null;

            var organizationService = new OrganizationService(CrmConnection.Parse(connectionDetail.GetOrganizationCrmConnectionString()));

            entities = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities;
            solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();

            entities = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities;
            assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();

            //var entities = instance.RetrieveMultiple(solutionsQuery).Entities;
            //solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
            solutions = solutions.Where(x => reference.Solutions.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<Solution>();

            //entities = instance.RetrieveMultiple(assembliesQuery).Entities;
            //assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
            assemblies = assemblies.Where(x => solutions.Where(y => y.Id == x.SolutionId).Count() > 0).ToArray<PluginAssembly>();

            this.ConnectionDetail = connectionDetail;
            this.Solutions = solutions;
            this.Assemblies = assemblies;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationSnapshot"/> class.
        /// </summary>
        /// <param name="connectionDetail"></param>
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
        /// <param name="fileName"></param>
        public OrganizationSnapshot(string fileName)
        {
            var document = new XmlDocument();
            document.Load(fileName);

            var solutions = new List<Solution>();
            var assemblies = new List<PluginAssembly>();

            this.Solutions = solutions.ToArray();
            this.Assemblies = assemblies.ToArray();

            foreach (XmlElement element in document.DocumentElement.ChildNodes)
            {
                if (element.Name == "solutions")
                {
                    foreach (XmlElement solution in element.ChildNodes)
                    {
                        var item = new Solution
                        {
                            Version = new Version(solution.Attributes["version"].Value),
                            UniqueName = solution.Attributes["unique-name"].Value,
                            FriendlyName = solution.Attributes["unique-name"].Value
                        };

                        solutions.Add(item);
                    }

                    this.Solutions = solutions.ToArray();
                }

                if (element.Name == "assemblies")
                {
                    foreach (XmlElement assembly in element.ChildNodes)
                    {
                        var item = new PluginAssembly()
                        {
                            Version = new Version(assembly.Attributes["version"].Value),
                            Name = assembly.Attributes["name"].Value
                        };

                        assemblies.Add(item);
                    }

                    this.Assemblies = assemblies.ToArray();
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
        /// Gets or sets connection detail for the organization
        /// </summary>
        public ConnectionDetail ConnectionDetail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets array of solutions available in the organization
        /// </summary>
        public Solution[] Solutions
        {
            get;
            set;
        }

        #endregion Public Properties

        #region Public Methods

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

                attribute = document.CreateAttribute("name");
                attribute.Value = assembly.Name;
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