using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ExakTime.ParkingLot.Core.Services
{
    /// <summary>
    /// A simple thread-safe auto-incrementing Id generator singletion.
    /// </summary>
    internal sealed class AutoIdGenerator
    {
        static AutoIdGenerator() { }

        private AutoIdGenerator() { }

        /// <summary>
        /// Get the one and only generator instance
        /// </summary>
        public static AutoIdGenerator Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Get the next auto-incremented Id.
        /// </summary>
        /// <returns>An integer representing an Id.</returns>
        public int GetNextId()
        {
            Interlocked.Increment(ref _nextId);

            return _nextId;
        }

        private int _nextId;

        private static readonly AutoIdGenerator instance = new AutoIdGenerator();
    }
}
