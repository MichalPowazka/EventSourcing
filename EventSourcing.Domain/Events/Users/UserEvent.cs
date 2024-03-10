using EventSourcing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Events.Users
{
    public class UserEvent
    {
        public string UniqueId { get; set; }
        public UserEventType Type { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

    }

    public enum UserEventType
    {
        [Description("Register")]
        Register,

        [Description("SuccessLogin")]
        SuccessLogin,

        [Description("FailedLogin")]
        FailedLogin,

        [Description("SuccessChangePassword")]
        SuccessChangePassword,

        [Description("FailedChangePassword")]
        FailedChangePassword,

        [Description("SuccessChangeData")]
        SuccessChangeData,

        [Description("FailedChangeData")]
        FailedChangeData

    }
}
