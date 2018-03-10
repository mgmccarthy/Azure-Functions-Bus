﻿using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFBus
{
    /// <summary>
    /// This interface defines that a message will continue a saga. 
    /// </summary>
    public interface IHandleWithCorrelation<MessageType>
    {
        /// <summary>
        /// Handles a message
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="message"></param>
        /// <param name="Log"></param>
        Task HandleAsync(IBus bus, MessageType message, TraceWriter Log);

        /// <summary>
        /// Defines how a message correlates to a saga instance
        /// </summary>
        Task<SagaData> LookForInstance(MessageType message);
    }
}