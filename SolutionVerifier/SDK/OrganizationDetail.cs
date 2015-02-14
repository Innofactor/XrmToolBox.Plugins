namespace Cinteros.Xrm.SolutionVerifier.SDK
{
    using System.Linq;
    using Cinteros.Xrm.SolutionVerifier.Utils;
    using McTools.Xrm.Connection;
    using Microsoft.Xrm.Client;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;

    public class OrganizationDetail
    {
        #region Public Fields

        public ConnectionDetail ConnectionDetail;

        /// <summary>
        /// Array of solutions available in the organization
        /// </summary>
        public Solution[] Solutions;

        #endregion Public Fields

        #region Public Constructors

        public OrganizationDetail(ConnectionDetail connectionDetail, Solution[] solutions)
        {
            this.ConnectionDetail = connectionDetail;
            this.Solutions = solutions;
        }

        public OrganizationDetail(ConnectionDetail connectionDetail, Solution[] reference, CrmConnection CrmConnection)
        {
            Solution[] solutions = null;
            PluginAssembly[] assemblies = null;
            DataCollection<Entity> entities = null;

            var organizationService = new OrganizationService(CrmConnection);

            entities = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities;
            solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();

            entities = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities;
            assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();

            //var entities = instance.RetrieveMultiple(solutionsQuery).Entities;
            //solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
            solutions = solutions.Where(x => reference.Where(y => y.UniqueName == x.UniqueName).Count() > 0).ToArray<Solution>();

            //entities = instance.RetrieveMultiple(assembliesQuery).Entities;
            //assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
            assemblies = assemblies.Where(x => solutions.Where(y => y.Id == x.SolutionId).Count() > 0).ToArray<PluginAssembly>();

            foreach (var solution in solutions)
            {
                solution.Assemblies = assemblies.Where(x => x.SolutionId == solution.Id).ToArray<PluginAssembly>();
            }

            this.ConnectionDetail = connectionDetail;
            this.Solutions = solutions;
        }

        public OrganizationDetail(ConnectionDetail connectionDetail, IOrganizationService organizationService)
        {
            var solutions = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities.Select(x => new Solution(x)).ToArray<Solution>();

            var assemblies = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities.Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
            assemblies = assemblies.Where(x => solutions.Where(y => y.Id == x.SolutionId).Count() > 0).ToArray<PluginAssembly>();

            for (int i = 0; i < solutions.Length; i++)
            {
                solutions[i].Assemblies = assemblies.Where(x => x.SolutionId == solutions[i].Id).ToArray<PluginAssembly>();
            }

            this.ConnectionDetail = connectionDetail;
            this.Solutions = solutions;
        }

        #endregion Public Constructors
    }
}