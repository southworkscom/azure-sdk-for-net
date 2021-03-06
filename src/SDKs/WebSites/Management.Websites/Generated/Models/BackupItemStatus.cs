// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.WebSites.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for BackupItemStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BackupItemStatus
    {
        [EnumMember(Value = "InProgress")]
        InProgress,
        [EnumMember(Value = "Failed")]
        Failed,
        [EnumMember(Value = "Succeeded")]
        Succeeded,
        [EnumMember(Value = "TimedOut")]
        TimedOut,
        [EnumMember(Value = "Created")]
        Created,
        [EnumMember(Value = "Skipped")]
        Skipped,
        [EnumMember(Value = "PartiallySucceeded")]
        PartiallySucceeded,
        [EnumMember(Value = "DeleteInProgress")]
        DeleteInProgress,
        [EnumMember(Value = "DeleteFailed")]
        DeleteFailed,
        [EnumMember(Value = "Deleted")]
        Deleted
    }
    internal static class BackupItemStatusEnumExtension
    {
        internal static string ToSerializedValue(this BackupItemStatus? value)
        {
            return value == null ? null : ((BackupItemStatus)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this BackupItemStatus value)
        {
            switch( value )
            {
                case BackupItemStatus.InProgress:
                    return "InProgress";
                case BackupItemStatus.Failed:
                    return "Failed";
                case BackupItemStatus.Succeeded:
                    return "Succeeded";
                case BackupItemStatus.TimedOut:
                    return "TimedOut";
                case BackupItemStatus.Created:
                    return "Created";
                case BackupItemStatus.Skipped:
                    return "Skipped";
                case BackupItemStatus.PartiallySucceeded:
                    return "PartiallySucceeded";
                case BackupItemStatus.DeleteInProgress:
                    return "DeleteInProgress";
                case BackupItemStatus.DeleteFailed:
                    return "DeleteFailed";
                case BackupItemStatus.Deleted:
                    return "Deleted";
            }
            return null;
        }

        internal static BackupItemStatus? ParseBackupItemStatus(this string value)
        {
            switch( value )
            {
                case "InProgress":
                    return BackupItemStatus.InProgress;
                case "Failed":
                    return BackupItemStatus.Failed;
                case "Succeeded":
                    return BackupItemStatus.Succeeded;
                case "TimedOut":
                    return BackupItemStatus.TimedOut;
                case "Created":
                    return BackupItemStatus.Created;
                case "Skipped":
                    return BackupItemStatus.Skipped;
                case "PartiallySucceeded":
                    return BackupItemStatus.PartiallySucceeded;
                case "DeleteInProgress":
                    return BackupItemStatus.DeleteInProgress;
                case "DeleteFailed":
                    return BackupItemStatus.DeleteFailed;
                case "Deleted":
                    return BackupItemStatus.Deleted;
            }
            return null;
        }
    }
}
