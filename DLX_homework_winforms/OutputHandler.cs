

namespace DLX_homework_winforms
{
    internal class OutputHandler
    {
        private readonly RichTextBox _richTextBox;

        public OutputHandler(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
        }

        public void AppendMessage(string message, MessageType type) 
        {
            Color messageColor;
            FontStyle messageFontStyle = FontStyle.Regular;

            switch (type)
            {
                case MessageType.Success:
                    messageColor = Color.Green;
                    messageFontStyle = FontStyle.Bold;
                    break;
                case MessageType.Danger:
                    messageColor = Color.Red;
                    messageFontStyle = FontStyle.Bold;
                    break;
                default:
                    messageColor = Color.Black;
                    break;
            }

            _richTextBox.SelectionStart = _richTextBox.TextLength;
            _richTextBox.SelectionLength = 0;

            _richTextBox.SelectionColor = messageColor;
            _richTextBox.SelectionFont = new Font(_richTextBox.Font, messageFontStyle);
            _richTextBox.AppendText(message);
            _richTextBox.SelectionColor = _richTextBox.ForeColor;
            _richTextBox.SelectionFont = new Font(_richTextBox.Font, FontStyle.Regular);

            _richTextBox.AppendText(Environment.NewLine);
        }
    }

    public enum MessageType
    {
        Default,
        Success,
        Danger
    }
}
