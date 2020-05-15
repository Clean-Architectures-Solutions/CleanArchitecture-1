using Audit.Application.Common.Interfaces;
using System;

namespace Audit.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
