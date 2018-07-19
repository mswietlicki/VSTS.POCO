using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VSTS.POCO.WorkItems.Model
{
    public class WorkItem
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public int Url { get; set; }
        public Dictionary<string, string> Fields { get; set; }

        [IgnoreDataMember]
        public string Title
        {
            get => Fields["System.Title"];
            set => Fields["System.Title"] = value;
        }

        public string Description { get; set; }
        public string AreaPath { get; set; }
        public string TeamProject { get; set; }
        public string IterationPath { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public WorkItemState State { get; set; }
        public WorkItemReason Reason { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ChangedDate { get; set; }
        public string ChangedBy { get; set; }
        public DateTime StateChangeDate { get; set; }
        public int Priority { get; set; }
        public string ValueArea { get; set; }
    }

    public enum WorkItemReason
    {
        New
    }

    public enum WorkItemState
    {
        New,
        Active,
        Qa,
        Closed,
        Removed
    }

    public enum WorkItemType
    {
        Bug,
        Task,
        [EnumMember(Value = "User Story")]
        UserStory
    }

    public enum WorkItemExpand
    {
        None,
        Relations
    }
}