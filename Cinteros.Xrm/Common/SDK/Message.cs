namespace Cinteros.Xrm.Common.SDK
{
    using Microsoft.Xrm.Sdk;
    using System;

    public class Message
    {
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

        #region Public Methods

        public static Message CreateFromStep(Entity entity)
        {
            if (entity == null)
            {
                return new Message();
            }

            var filter = new MessageFilter();

            if (entity.Attributes.ContainsKey("message.sdkmessagefilterid"))
            {
                filter.Id = (Guid)((AliasedValue)entity.Attributes["message.sdkmessagefilterid"]).Value;
            }

            if (entity.Attributes.ContainsKey("filter.objecttypecode"))
            {
                filter.EntityName = (string)((AliasedValue)entity.Attributes["filter.objecttypecode"]).Value;
            }

            var message = new Message
            {
                Filter = filter
            };

            if (entity.Attributes.ContainsKey("message.sdkmessageid"))
            {
                message.Id = (Guid)((AliasedValue)entity.Attributes["message.sdkmessageid"]).Value;
            }

            if (entity.Attributes.ContainsKey("message.name"))
            {
                message.FriendlyName = (string)((AliasedValue)entity.Attributes["message.name"]).Value;
            }

            return message;
        }

        #endregion Public Methods
    }
}