using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace UniTaskFlow01.Module.BusinessObjects
{
    // [DomainComponent] tells XAF: "This is a temporary UI object, don't build a SQL table for it!"
    [DomainComponent]
    public class AskAiDialog
    {
        [FieldSize(FieldSizeAttribute.Unlimited)]
        public string Question { get; set; }

        [FieldSize(FieldSizeAttribute.Unlimited)]
        public string AiResponse { get; set; }
    }
}