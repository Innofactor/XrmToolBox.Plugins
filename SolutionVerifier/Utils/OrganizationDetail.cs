namespace Cinteros.Xrm.SolutionVerifier.Utils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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

        public OrganizationDetail(Solution[] reference, KeyValuePair<ConnectionDetail, CrmConnection> service)
        {
            Solution[] solutions = null;
            PluginAssembly[] assemblies = null;

            var organizationService = new OrganizationService(service.Value);

            var solutionsTask = new Task(() =>
            {
                var entities = organizationService.RetrieveMultiple(Helpers.CreateSolutionsQuery()).Entities;
                solutions = entities.ToArray<Entity>().Select(x => new Solution(x)).ToArray<Solution>();
            });

            var assembliesTask = new Task(() =>
            {
                var entities = organizationService.RetrieveMultiple(Helpers.CreateAssembliesQuery()).Entities;
                assemblies = entities.ToArray<Entity>().Select(x => new PluginAssembly(x)).ToArray<PluginAssembly>();
            });

            var tasks = new List<Task>
            {
                solutionsTask,
                assembliesTask
            };

            tasks.ForEach(x => x.Start());

            do
            {
            } while (tasks.Where(x => x.Status == TaskStatus.Running).Count() != 0);

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

            this.ConnectionDetail = service.Key;
            this.Solutions = solutions;
        }

        #endregion Public Constructors
    }
}