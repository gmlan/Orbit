using System.ComponentModel;

namespace Com.Qualcomm.Qswat.Model.Enums
{
    public enum TicketStatus
    {
        [Description("Ticket is open and waiting to be assigned")]
        Pending = 0,

        [Description("Ticket is assigned")]
        Assigned,

        [Description("Ticket's owner is working on it")]
        InProgress,

        [Description("Ticket is resolved by assigee")]
        Resolved,

        [Description("Ticket is closed by owner")]
        Closed,

        [Description("Ticket is cancelled")]
        Cancelled
    }
}
