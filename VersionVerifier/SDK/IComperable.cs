namespace Cinteros.Xrm.SolutionVerifier.SDK
{
    using System;

    interface IComperable
    {
        Guid Id
        {
            get;
        }
        
        string FriendlyName 
        { 
            get; 
            set; 
        }

        string UniqueName
        {
            get;
            set;
        }
        
        Version Version 
        { 
            get; 
            set; 
        }
    }
}
