namespace Cinteros.XrmToolbox.Compare.Utils
{
    using Microsoft.Xrm.Sdk.Query;

    public static class Helpers
    {
        #region Public Methods

        /// <summary>
        /// Creates query expression that will get information about all solutions in the system
        /// </summary>
        /// <returns></returns>
        public static QueryExpression CreateSolutionsQuery()
        {
            var query = new QueryExpression(Constants.E_SOLUTION);
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(Constants.A_ISVISIBLE, ConditionOperator.Equal, true);
            query.Criteria.AddCondition(Constants.A_UNIQUENAME, ConditionOperator.NotEqual, Constants.SOLUTION_DEFAULT);
            query.ColumnSet = new ColumnSet(new string[] { Constants.A_UNIQUENAME, Constants.A_FRIENDLYNAME, Constants.A_VERSION, Constants.A_ISMANAGED });

            return query;
        }

        #endregion Public Methods
    }
}