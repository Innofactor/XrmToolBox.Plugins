namespace Cinteros.Xrm.VersionVerifier.SDK
{
    using System;

    public interface IComparableEntity
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
