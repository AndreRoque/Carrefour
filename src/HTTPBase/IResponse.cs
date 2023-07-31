namespace HTTPBase
{
    public interface IResponse : IMessage
    {
        #region Public Methods

        void AddMessage(MessageData messageData);

        void SetStatus(bool status);

        void SetSuccess();

        #endregion Public Methods
    }
}