namespace Cinteros.Xrm.Common.SDK
{
    using Microsoft.Xrm.Sdk;
    using System;

    public class Message
    {
        #region Public Constructors

        public static Message CreateFromStep(Entity entity)
        {
            var message = new Message
            {
                Filter = new MessageFilter
                {
                    Id = (Guid)((AliasedValue)entity.Attributes["message.sdkmessagefilterid"]).Value,
                    EntityName = (string)((AliasedValue)entity.Attributes["filter.objecttypecode"]).Value
                },
                Id = (Guid)((AliasedValue)entity.Attributes["message.sdkmessageid"]).Value,
                FriendlyName = (string)((AliasedValue)entity.Attributes["message.name"]).Value
            };

            return message;
        }

        #endregion Public Constructors

        #region Public Properties

        public MessageFilter Filter
        {
            get;
            set;
        }

        public string FriendlyName
        {
            get;
            set;
        }

        public Guid Id
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}