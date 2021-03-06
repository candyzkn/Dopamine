﻿using SQLite;

namespace Dopamine.Core.Database.Entities
{
    public class QueuedTrack
    {
        #region Properties
        [PrimaryKey(), AutoIncrement()]
        public long QueuedTrackID { get; set; }
        public string QueueID { get; set; }
        public string Path { get; set; }
        public string SafePath { get; set; }
        public long IsPlaying { get; set; }
        public long ProgressSeconds { get; set; }
        public long OrderID { get; set; }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return this.QueuedTrackID.Equals(((QueuedTrack)obj).QueuedTrackID);
        }

        public override int GetHashCode()
        {
            return new { this.QueuedTrackID }.GetHashCode();
        }
        #endregion
    }
}
