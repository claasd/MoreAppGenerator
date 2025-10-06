#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestUserAccountInformation(this RestUserAccountInformation item, RestUserAccountInformation other, bool deepClone = true) {
            item.FirstName = other.FirstName;
            item.LastName = other.LastName;
            item.Language = (RestUserAccountInformation.LanguageValue)other.Language;
            item.Country = other.Country;
            item.ReceiveNewsLetter = other.ReceiveNewsLetter;
            item.TimeZone = deepClone ? other.TimeZone?.DeepClone() : other.TimeZone;
        }
        
        /// <summary>
        /// Returns a new object of RestUserAccountInformation with fileds filled from RestUserAccountInformation. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestUserAccountInformation ToRestUserAccountInformation(this RestUserAccountInformation other, bool deepClone = true) => new RestUserAccountInformation() { 
            FirstName = other.FirstName,
            LastName = other.LastName,
            Language = (RestUserAccountInformation.LanguageValue)other.Language,
            Country = other.Country,
            ReceiveNewsLetter = other.ReceiveNewsLetter,
            TimeZone = deepClone ? other.TimeZone?.DeepClone() : other.TimeZone
        };
        
        /// <summary>
        /// Selects the type RestUserAccountInformation from a IQueryable<RestUserAccountInformation>
        /// </summary>
        public static IQueryable<RestUserAccountInformation> SelectAsRestUserAccountInformation(this IQueryable<RestUserAccountInformation> query) => query.Select(other => new RestUserAccountInformation() { 
            FirstName = other.FirstName,
            LastName = other.LastName,
            Language = (RestUserAccountInformation.LanguageValue)other.Language,
            Country = other.Country,
            ReceiveNewsLetter = other.ReceiveNewsLetter,
            TimeZone = other.TimeZone
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithJsonError(this JsonError item, JsonError other, bool deepClone = true) {
            item.Status = other.Status;
            item.Message = other.Message;
            item.Scope = other.Scope == null ? null : (JsonError.ScopeValue)other.Scope;
            item.TraceId = other.TraceId;
            item.Details = deepClone ? other.Details?.ToJsonErrorDetails() : other.Details;
        }
        
        /// <summary>
        /// Returns a new object of JsonError with fileds filled from JsonError. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static JsonError ToJsonError(this JsonError other, bool deepClone = true) => new JsonError() { 
            Status = other.Status,
            Message = other.Message,
            Scope = other.Scope == null ? null : (JsonError.ScopeValue)other.Scope,
            TraceId = other.TraceId,
            Details = deepClone ? other.Details?.ToJsonErrorDetails() : other.Details
        };
        
        /// <summary>
        /// Selects the type JsonError from a IQueryable<JsonError>
        /// </summary>
        public static IQueryable<JsonError> SelectAsJsonError(this IQueryable<JsonError> query) => query.Select(other => new JsonError() { 
            Status = other.Status,
            Message = other.Message,
            Scope = other.Scope == null ? null : (JsonError.ScopeValue)other.Scope,
            TraceId = other.TraceId,
            Details = other.Details
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestDataSource(this RestDataSource item, RestDataSource other, bool deepClone = true) {
            item.Id = other.Id;
            item.CustomerId = other.CustomerId;
            item.Name = other.Name;
            item.UrlConfiguration = deepClone ? other.UrlConfiguration?.ToRestUrlConfiguration() : other.UrlConfiguration;
            item.GoogleConfiguration = deepClone ? other.GoogleConfiguration?.ToGoogleConfiguration() : other.GoogleConfiguration;
            item.UpdateStatus = other.UpdateStatus == null ? null : (RestDataSource.UpdateStatusValue)other.UpdateStatus;
            item.LastUpdated = other.LastUpdated;
            item.LastSuccessfulUpdate = other.LastSuccessfulUpdate;
            item.LastUpdateType = other.LastUpdateType == null ? null : (RestDataSource.LastUpdateTypeValue)other.LastUpdateType;
            item.LastUpdateWarningMessages = deepClone ? other.LastUpdateWarningMessages?.ToList() : other.LastUpdateWarningMessages;
            item.ColumnMapping = deepClone ? other.ColumnMapping?.Select(value=>value?.ToDataKey())?.ToList() : other.ColumnMapping;
            item.Enabled = other.Enabled;
            item.FailedExecutionCount = other.FailedExecutionCount;
            item.Version = other.Version;
        }
        
        /// <summary>
        /// Returns a new object of RestDataSource with fileds filled from RestDataSource. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestDataSource ToRestDataSource(this RestDataSource other, bool deepClone = true) => new RestDataSource() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            Name = other.Name,
            UrlConfiguration = deepClone ? other.UrlConfiguration?.ToRestUrlConfiguration() : other.UrlConfiguration,
            GoogleConfiguration = deepClone ? other.GoogleConfiguration?.ToGoogleConfiguration() : other.GoogleConfiguration,
            UpdateStatus = other.UpdateStatus == null ? null : (RestDataSource.UpdateStatusValue)other.UpdateStatus,
            LastUpdated = other.LastUpdated,
            LastSuccessfulUpdate = other.LastSuccessfulUpdate,
            LastUpdateType = other.LastUpdateType == null ? null : (RestDataSource.LastUpdateTypeValue)other.LastUpdateType,
            LastUpdateWarningMessages = deepClone ? other.LastUpdateWarningMessages?.ToList() : other.LastUpdateWarningMessages,
            ColumnMapping = deepClone ? other.ColumnMapping?.Select(value=>value?.ToDataKey())?.ToList() : other.ColumnMapping,
            Enabled = other.Enabled,
            FailedExecutionCount = other.FailedExecutionCount,
            Version = other.Version
        };
        
        /// <summary>
        /// Selects the type RestDataSource from a IQueryable<RestDataSource>
        /// </summary>
        public static IQueryable<RestDataSource> SelectAsRestDataSource(this IQueryable<RestDataSource> query) => query.Select(other => new RestDataSource() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            Name = other.Name,
            UrlConfiguration = other.UrlConfiguration,
            GoogleConfiguration = other.GoogleConfiguration,
            UpdateStatus = other.UpdateStatus == null ? null : (RestDataSource.UpdateStatusValue)other.UpdateStatus,
            LastUpdated = other.LastUpdated,
            LastSuccessfulUpdate = other.LastSuccessfulUpdate,
            LastUpdateType = other.LastUpdateType == null ? null : (RestDataSource.LastUpdateTypeValue)other.LastUpdateType,
            LastUpdateWarningMessages = other.LastUpdateWarningMessages,
            ColumnMapping = other.ColumnMapping,
            Enabled = other.Enabled,
            FailedExecutionCount = other.FailedExecutionCount,
            Version = other.Version
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestUrlConfiguration(this RestUrlConfiguration item, RestUrlConfiguration other, bool deepClone = true) {
            item.Url = other.Url;
            item.Credentials = deepClone ? other.Credentials?.ToRestCredentials() : other.Credentials;
            item.RequestHeaders = deepClone ? other.RequestHeaders?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.RequestHeaders;
            item.Parameters = deepClone ? other.Parameters?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Parameters;
            item.UpdateInterval = (RestUrlConfiguration.UpdateIntervalValue)other.UpdateInterval;
        }
        
        /// <summary>
        /// Returns a new object of RestUrlConfiguration with fileds filled from RestUrlConfiguration. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestUrlConfiguration ToRestUrlConfiguration(this RestUrlConfiguration other, bool deepClone = true) => new RestUrlConfiguration() { 
            Url = other.Url,
            Credentials = deepClone ? other.Credentials?.ToRestCredentials() : other.Credentials,
            RequestHeaders = deepClone ? other.RequestHeaders?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.RequestHeaders,
            Parameters = deepClone ? other.Parameters?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Parameters,
            UpdateInterval = (RestUrlConfiguration.UpdateIntervalValue)other.UpdateInterval
        };
        
        /// <summary>
        /// Selects the type RestUrlConfiguration from a IQueryable<RestUrlConfiguration>
        /// </summary>
        public static IQueryable<RestUrlConfiguration> SelectAsRestUrlConfiguration(this IQueryable<RestUrlConfiguration> query) => query.Select(other => new RestUrlConfiguration() { 
            Url = other.Url,
            Credentials = other.Credentials,
            RequestHeaders = other.RequestHeaders,
            Parameters = other.Parameters,
            UpdateInterval = (RestUrlConfiguration.UpdateIntervalValue)other.UpdateInterval
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestCredentials(this RestCredentials item, RestCredentials other, bool deepClone = true) {
            item.Username = other.Username;
            item.Password = other.Password;
        }
        
        /// <summary>
        /// Returns a new object of RestCredentials with fileds filled from RestCredentials. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestCredentials ToRestCredentials(this RestCredentials other, bool deepClone = true) => new RestCredentials() { 
            Username = other.Username,
            Password = other.Password
        };
        
        /// <summary>
        /// Selects the type RestCredentials from a IQueryable<RestCredentials>
        /// </summary>
        public static IQueryable<RestCredentials> SelectAsRestCredentials(this IQueryable<RestCredentials> query) => query.Select(other => new RestCredentials() { 
            Username = other.Username,
            Password = other.Password
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGoogleConfiguration(this GoogleConfiguration item, GoogleConfiguration other, bool deepClone = true) {
            item.SpreadsheetId = other.SpreadsheetId;
            item.UpdateInterval = other.UpdateInterval == null ? null : (GoogleConfiguration.UpdateIntervalValue)other.UpdateInterval;
        }
        
        /// <summary>
        /// Returns a new object of GoogleConfiguration with fileds filled from GoogleConfiguration. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static GoogleConfiguration ToGoogleConfiguration(this GoogleConfiguration other, bool deepClone = true) => new GoogleConfiguration() { 
            SpreadsheetId = other.SpreadsheetId,
            UpdateInterval = other.UpdateInterval == null ? null : (GoogleConfiguration.UpdateIntervalValue)other.UpdateInterval
        };
        
        /// <summary>
        /// Selects the type GoogleConfiguration from a IQueryable<GoogleConfiguration>
        /// </summary>
        public static IQueryable<GoogleConfiguration> SelectAsGoogleConfiguration(this IQueryable<GoogleConfiguration> query) => query.Select(other => new GoogleConfiguration() { 
            SpreadsheetId = other.SpreadsheetId,
            UpdateInterval = other.UpdateInterval == null ? null : (GoogleConfiguration.UpdateIntervalValue)other.UpdateInterval
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithDataKey(this DataKey item, DataKey other, bool deepClone = true) {
            item.Id = other.Id;
            item.Label = other.Label;
        }
        
        /// <summary>
        /// Returns a new object of DataKey with fileds filled from DataKey. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static DataKey ToDataKey(this DataKey other, bool deepClone = true) => new DataKey() { 
            Id = other.Id,
            Label = other.Label
        };
        
        /// <summary>
        /// Selects the type DataKey from a IQueryable<DataKey>
        /// </summary>
        public static IQueryable<DataKey> SelectAsDataKey(this IQueryable<DataKey> query) => query.Select(other => new DataKey() { 
            Id = other.Id,
            Label = other.Label
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestCreateDataSource(this RestCreateDataSource item, RestCreateDataSource other, bool deepClone = true) {
            item.Name = other.Name;
            item.UrlConfiguration = deepClone ? other.UrlConfiguration?.ToRestUrlConfiguration() : other.UrlConfiguration;
            item.GoogleConfiguration = deepClone ? other.GoogleConfiguration?.ToGoogleConfiguration() : other.GoogleConfiguration;
        }
        
        /// <summary>
        /// Returns a new object of RestCreateDataSource with fileds filled from RestCreateDataSource. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestCreateDataSource ToRestCreateDataSource(this RestCreateDataSource other, bool deepClone = true) => new RestCreateDataSource() { 
            Name = other.Name,
            UrlConfiguration = deepClone ? other.UrlConfiguration?.ToRestUrlConfiguration() : other.UrlConfiguration,
            GoogleConfiguration = deepClone ? other.GoogleConfiguration?.ToGoogleConfiguration() : other.GoogleConfiguration
        };
        
        /// <summary>
        /// Selects the type RestCreateDataSource from a IQueryable<RestCreateDataSource>
        /// </summary>
        public static IQueryable<RestCreateDataSource> SelectAsRestCreateDataSource(this IQueryable<RestCreateDataSource> query) => query.Select(other => new RestCreateDataSource() { 
            Name = other.Name,
            UrlConfiguration = other.UrlConfiguration,
            GoogleConfiguration = other.GoogleConfiguration
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRole(this Role item, Role other, bool deepClone = true) {
            item.Name = other.Name;
            item.Permissions = deepClone ? other.Permissions?.ToList() : other.Permissions;
        }
        
        /// <summary>
        /// Returns a new object of Role with fileds filled from Role. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Role ToRole(this Role other, bool deepClone = true) => new Role() { 
            Name = other.Name,
            Permissions = deepClone ? other.Permissions?.ToList() : other.Permissions
        };
        
        /// <summary>
        /// Selects the type Role from a IQueryable<Role>
        /// </summary>
        public static IQueryable<Role> SelectAsRole(this IQueryable<Role> query) => query.Select(other => new Role() { 
            Name = other.Name,
            Permissions = other.Permissions
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithCreateRoleRequest(this CreateRoleRequest item, CreateRoleRequest other, bool deepClone = true) {
            item.Name = other.Name;
        }
        
        /// <summary>
        /// Returns a new object of CreateRoleRequest with fileds filled from CreateRoleRequest. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static CreateRoleRequest ToCreateRoleRequest(this CreateRoleRequest other, bool deepClone = true) => new CreateRoleRequest() { 
            Name = other.Name
        };
        
        /// <summary>
        /// Selects the type CreateRoleRequest from a IQueryable<CreateRoleRequest>
        /// </summary>
        public static IQueryable<CreateRoleRequest> SelectAsCreateRoleRequest(this IQueryable<CreateRoleRequest> query) => query.Select(other => new CreateRoleRequest() { 
            Name = other.Name
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestInvite(this RestInvite item, RestInvite other, bool deepClone = true) {
            item.Id = other.Id;
            item.CustomerId = other.CustomerId;
            item.EmailAddress = other.EmailAddress;
            item.Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants;
            item.Groups = deepClone ? other.Groups?.ToList() : other.Groups;
            item.Settings = deepClone ? other.Settings?.ToUserAccountInformation() : other.Settings;
            item.Status = other.Status == null ? null : (RestInvite.StatusValue)other.Status;
            item.ExpiresAt = other.ExpiresAt;
        }
        
        /// <summary>
        /// Returns a new object of RestInvite with fileds filled from RestInvite. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestInvite ToRestInvite(this RestInvite other, bool deepClone = true) => new RestInvite() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            EmailAddress = other.EmailAddress,
            Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants,
            Groups = deepClone ? other.Groups?.ToList() : other.Groups,
            Settings = deepClone ? other.Settings?.ToUserAccountInformation() : other.Settings,
            Status = other.Status == null ? null : (RestInvite.StatusValue)other.Status,
            ExpiresAt = other.ExpiresAt
        };
        
        /// <summary>
        /// Selects the type RestInvite from a IQueryable<RestInvite>
        /// </summary>
        public static IQueryable<RestInvite> SelectAsRestInvite(this IQueryable<RestInvite> query) => query.Select(other => new RestInvite() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            EmailAddress = other.EmailAddress,
            Grants = other.Grants,
            Groups = other.Groups,
            Settings = other.Settings,
            Status = other.Status == null ? null : (RestInvite.StatusValue)other.Status,
            ExpiresAt = other.ExpiresAt
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGrant(this Grant item, Grant other, bool deepClone = true) {
            item.CustomerId = other.CustomerId;
            item.ResourceType = other.ResourceType == null ? null : (Grant.ResourceTypeValue)other.ResourceType;
            item.RoleId = other.RoleId;
            item.ResourceId = other.ResourceId;
        }
        
        /// <summary>
        /// Returns a new object of Grant with fileds filled from Grant. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Grant ToGrant(this Grant other, bool deepClone = true) => new Grant() { 
            CustomerId = other.CustomerId,
            ResourceType = other.ResourceType == null ? null : (Grant.ResourceTypeValue)other.ResourceType,
            RoleId = other.RoleId,
            ResourceId = other.ResourceId
        };
        
        /// <summary>
        /// Selects the type Grant from a IQueryable<Grant>
        /// </summary>
        public static IQueryable<Grant> SelectAsGrant(this IQueryable<Grant> query) => query.Select(other => new Grant() { 
            CustomerId = other.CustomerId,
            ResourceType = other.ResourceType == null ? null : (Grant.ResourceTypeValue)other.ResourceType,
            RoleId = other.RoleId,
            ResourceId = other.ResourceId
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUserAccountInformation(this UserAccountInformation item, UserAccountInformation other, bool deepClone = true) {
            item.FirstName = other.FirstName;
            item.LastName = other.LastName;
            item.Language = other.Language == null ? null : (UserAccountInformation.LanguageValue)other.Language;
            item.Country = other.Country;
            item.ReceiveNewsLetter = other.ReceiveNewsLetter;
            item.TimeZone = deepClone ? other.TimeZone?.DeepClone() : other.TimeZone;
        }
        
        /// <summary>
        /// Returns a new object of UserAccountInformation with fileds filled from UserAccountInformation. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static UserAccountInformation ToUserAccountInformation(this UserAccountInformation other, bool deepClone = true) => new UserAccountInformation() { 
            FirstName = other.FirstName,
            LastName = other.LastName,
            Language = other.Language == null ? null : (UserAccountInformation.LanguageValue)other.Language,
            Country = other.Country,
            ReceiveNewsLetter = other.ReceiveNewsLetter,
            TimeZone = deepClone ? other.TimeZone?.DeepClone() : other.TimeZone
        };
        
        /// <summary>
        /// Selects the type UserAccountInformation from a IQueryable<UserAccountInformation>
        /// </summary>
        public static IQueryable<UserAccountInformation> SelectAsUserAccountInformation(this IQueryable<UserAccountInformation> query) => query.Select(other => new UserAccountInformation() { 
            FirstName = other.FirstName,
            LastName = other.LastName,
            Language = other.Language == null ? null : (UserAccountInformation.LanguageValue)other.Language,
            Country = other.Country,
            ReceiveNewsLetter = other.ReceiveNewsLetter,
            TimeZone = other.TimeZone
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestInviteUser(this RestInviteUser item, RestInviteUser other, bool deepClone = true) {
            item.EmailAddress = other.EmailAddress;
            item.Language = other.Language == null ? null : (RestInviteUser.LanguageValue)other.Language;
            item.Groups = deepClone ? other.Groups?.ToList() : other.Groups;
            item.Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants;
        }
        
        /// <summary>
        /// Returns a new object of RestInviteUser with fileds filled from RestInviteUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestInviteUser ToRestInviteUser(this RestInviteUser other, bool deepClone = true) => new RestInviteUser() { 
            EmailAddress = other.EmailAddress,
            Language = other.Language == null ? null : (RestInviteUser.LanguageValue)other.Language,
            Groups = deepClone ? other.Groups?.ToList() : other.Groups,
            Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants
        };
        
        /// <summary>
        /// Selects the type RestInviteUser from a IQueryable<RestInviteUser>
        /// </summary>
        public static IQueryable<RestInviteUser> SelectAsRestInviteUser(this IQueryable<RestInviteUser> query) => query.Select(other => new RestInviteUser() { 
            EmailAddress = other.EmailAddress,
            Language = other.Language == null ? null : (RestInviteUser.LanguageValue)other.Language,
            Groups = other.Groups,
            Grants = other.Grants
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGroup(this Group item, Group other, bool deepClone = true) {
            item.Id = other.Id;
            item.Name = other.Name;
            item.Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants;
            item.ExternallyManaged = other.ExternallyManaged;
        }
        
        /// <summary>
        /// Returns a new object of Group with fileds filled from Group. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Group ToGroup(this Group other, bool deepClone = true) => new Group() { 
            Id = other.Id,
            Name = other.Name,
            Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants,
            ExternallyManaged = other.ExternallyManaged
        };
        
        /// <summary>
        /// Selects the type Group from a IQueryable<Group>
        /// </summary>
        public static IQueryable<Group> SelectAsGroup(this IQueryable<Group> query) => query.Select(other => new Group() { 
            Id = other.Id,
            Name = other.Name,
            Grants = other.Grants,
            ExternallyManaged = other.ExternallyManaged
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithCreateGroupRequest(this CreateGroupRequest item, CreateGroupRequest other, bool deepClone = true) {
            item.Name = other.Name;
        }
        
        /// <summary>
        /// Returns a new object of CreateGroupRequest with fileds filled from CreateGroupRequest. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static CreateGroupRequest ToCreateGroupRequest(this CreateGroupRequest other, bool deepClone = true) => new CreateGroupRequest() { 
            Name = other.Name
        };
        
        /// <summary>
        /// Selects the type CreateGroupRequest from a IQueryable<CreateGroupRequest>
        /// </summary>
        public static IQueryable<CreateGroupRequest> SelectAsCreateGroupRequest(this IQueryable<CreateGroupRequest> query) => query.Select(other => new CreateGroupRequest() { 
            Name = other.Name
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSimpleFilter(this SimpleFilter item, SimpleFilter other, bool deepClone = true) {
            item.PageSize = other.PageSize;
            item.Sort = deepClone ? other.Sort?.Select(value=>value?.ToSortProperty())?.ToList() : other.Sort;
            item.Query = deepClone ? other.Query?.Select(value=>value?.ToFilterQuery())?.ToList() : other.Query;
        }
        
        /// <summary>
        /// Returns a new object of SimpleFilter with fileds filled from SimpleFilter. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static SimpleFilter ToSimpleFilter(this SimpleFilter other, bool deepClone = true) => new SimpleFilter() { 
            PageSize = other.PageSize,
            Sort = deepClone ? other.Sort?.Select(value=>value?.ToSortProperty())?.ToList() : other.Sort,
            Query = deepClone ? other.Query?.Select(value=>value?.ToFilterQuery())?.ToList() : other.Query
        };
        
        /// <summary>
        /// Selects the type SimpleFilter from a IQueryable<SimpleFilter>
        /// </summary>
        public static IQueryable<SimpleFilter> SelectAsSimpleFilter(this IQueryable<SimpleFilter> query) => query.Select(other => new SimpleFilter() { 
            PageSize = other.PageSize,
            Sort = other.Sort,
            Query = other.Query
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSortProperty(this SortProperty item, SortProperty other, bool deepClone = true) {
            item.Key = other.Key;
            item.Direction = other.Direction;
        }
        
        /// <summary>
        /// Returns a new object of SortProperty with fileds filled from SortProperty. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static SortProperty ToSortProperty(this SortProperty other, bool deepClone = true) => new SortProperty() { 
            Key = other.Key,
            Direction = other.Direction
        };
        
        /// <summary>
        /// Selects the type SortProperty from a IQueryable<SortProperty>
        /// </summary>
        public static IQueryable<SortProperty> SelectAsSortProperty(this IQueryable<SortProperty> query) => query.Select(other => new SortProperty() { 
            Key = other.Key,
            Direction = other.Direction
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFilterQuery(this FilterQuery item, FilterQuery other, bool deepClone = true) {
            item.Path = other.Path;
            item.Value = deepClone ? other.Value?.DeepClone() : other.Value;
            item.Type = other.Type;
        }
        
        /// <summary>
        /// Returns a new object of FilterQuery with fileds filled from FilterQuery. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FilterQuery ToFilterQuery(this FilterQuery other, bool deepClone = true) => new FilterQuery() { 
            Path = other.Path,
            Value = deepClone ? other.Value?.DeepClone() : other.Value,
            Type = other.Type
        };
        
        /// <summary>
        /// Selects the type FilterQuery from a IQueryable<FilterQuery>
        /// </summary>
        public static IQueryable<FilterQuery> SelectAsFilterQuery(this IQueryable<FilterQuery> query) => query.Select(other => new FilterQuery() { 
            Path = other.Path,
            Value = other.Value,
            Type = other.Type
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestPageableTasks(this RestPageableTasks item, RestPageableTasks other, bool deepClone = true) {
            item.TotalSize = other.TotalSize;
            item.Elements = deepClone ? other.Elements?.Select(value=>value?.ToRestTask())?.ToList() : other.Elements;
        }
        
        /// <summary>
        /// Returns a new object of RestPageableTasks with fileds filled from RestPageableTasks. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestPageableTasks ToRestPageableTasks(this RestPageableTasks other, bool deepClone = true) => new RestPageableTasks() { 
            TotalSize = other.TotalSize,
            Elements = deepClone ? other.Elements?.Select(value=>value?.ToRestTask())?.ToList() : other.Elements
        };
        
        /// <summary>
        /// Selects the type RestPageableTasks from a IQueryable<RestPageableTasks>
        /// </summary>
        public static IQueryable<RestPageableTasks> SelectAsRestPageableTasks(this IQueryable<RestPageableTasks> query) => query.Select(other => new RestPageableTasks() { 
            TotalSize = other.TotalSize,
            Elements = other.Elements
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestTask(this RestTask item, RestTask other, bool deepClone = true) {
            item.Id = other.Id;
            item.CustomerId = other.CustomerId;
            item.FormId = other.FormId;
            item.FormName = other.FormName;
            item.Description = other.Description;
            item.FormIcon = other.FormIcon;
            item.FormIconColor = other.FormIconColor;
            item.Users = deepClone ? other.Users?.ToList() : other.Users;
            item.Message = other.Message;
            item.Dates = deepClone ? other.Dates?.ToTaskDates() : other.Dates;
            item.Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data;
            item.Status = other.Status == null ? null : (RestTask.StatusValue)other.Status;
            item.Fulfilments = deepClone ? other.Fulfilments?.Select(value=>value?.ToTaskFulfilment())?.ToList() : other.Fulfilments;
        }
        
        /// <summary>
        /// Returns a new object of RestTask with fileds filled from RestTask. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestTask ToRestTask(this RestTask other, bool deepClone = true) => new RestTask() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            FormId = other.FormId,
            FormName = other.FormName,
            Description = other.Description,
            FormIcon = other.FormIcon,
            FormIconColor = other.FormIconColor,
            Users = deepClone ? other.Users?.ToList() : other.Users,
            Message = other.Message,
            Dates = deepClone ? other.Dates?.ToTaskDates() : other.Dates,
            Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data,
            Status = other.Status == null ? null : (RestTask.StatusValue)other.Status,
            Fulfilments = deepClone ? other.Fulfilments?.Select(value=>value?.ToTaskFulfilment())?.ToList() : other.Fulfilments
        };
        
        /// <summary>
        /// Selects the type RestTask from a IQueryable<RestTask>
        /// </summary>
        public static IQueryable<RestTask> SelectAsRestTask(this IQueryable<RestTask> query) => query.Select(other => new RestTask() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            FormId = other.FormId,
            FormName = other.FormName,
            Description = other.Description,
            FormIcon = other.FormIcon,
            FormIconColor = other.FormIconColor,
            Users = other.Users,
            Message = other.Message,
            Dates = other.Dates,
            Data = other.Data,
            Status = other.Status == null ? null : (RestTask.StatusValue)other.Status,
            Fulfilments = other.Fulfilments
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTaskDates(this TaskDates item, TaskDates other, bool deepClone = true) {
            item.CreationDate = other.CreationDate;
            item.PublishDate = other.PublishDate;
            item.InformationDate = other.InformationDate;
        }
        
        /// <summary>
        /// Returns a new object of TaskDates with fileds filled from TaskDates. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static TaskDates ToTaskDates(this TaskDates other, bool deepClone = true) => new TaskDates() { 
            CreationDate = other.CreationDate,
            PublishDate = other.PublishDate,
            InformationDate = other.InformationDate
        };
        
        /// <summary>
        /// Selects the type TaskDates from a IQueryable<TaskDates>
        /// </summary>
        public static IQueryable<TaskDates> SelectAsTaskDates(this IQueryable<TaskDates> query) => query.Select(other => new TaskDates() { 
            CreationDate = other.CreationDate,
            PublishDate = other.PublishDate,
            InformationDate = other.InformationDate
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTaskFulfilment(this TaskFulfilment item, TaskFulfilment other, bool deepClone = true) {
            item.UserId = other.UserId;
            item.Date = other.Date;
            item.FormId = other.FormId;
            item.RegistrationId = other.RegistrationId;
        }
        
        /// <summary>
        /// Returns a new object of TaskFulfilment with fileds filled from TaskFulfilment. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static TaskFulfilment ToTaskFulfilment(this TaskFulfilment other, bool deepClone = true) => new TaskFulfilment() { 
            UserId = other.UserId,
            Date = other.Date,
            FormId = other.FormId,
            RegistrationId = other.RegistrationId
        };
        
        /// <summary>
        /// Selects the type TaskFulfilment from a IQueryable<TaskFulfilment>
        /// </summary>
        public static IQueryable<TaskFulfilment> SelectAsTaskFulfilment(this IQueryable<TaskFulfilment> query) => query.Select(other => new TaskFulfilment() { 
            UserId = other.UserId,
            Date = other.Date,
            FormId = other.FormId,
            RegistrationId = other.RegistrationId
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTaskCreateRequest(this TaskCreateRequest item, TaskCreateRequest other, bool deepClone = true) {
            item.Recipients = deepClone ? other.Recipients?.ToList() : other.Recipients;
            item.Message = other.Message;
            item.Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data;
            item.InformationDate = other.InformationDate;
            item.PublishDate = deepClone ? other.PublishDate?.ToTaskPublishInfo() : other.PublishDate;
            item.PublishInfo = deepClone ? other.PublishInfo?.ToTaskPublishInfo() : other.PublishInfo;
        }
        
        /// <summary>
        /// Returns a new object of TaskCreateRequest with fileds filled from TaskCreateRequest. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static TaskCreateRequest ToTaskCreateRequest(this TaskCreateRequest other, bool deepClone = true) => new TaskCreateRequest() { 
            Recipients = deepClone ? other.Recipients?.ToList() : other.Recipients,
            Message = other.Message,
            Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data,
            InformationDate = other.InformationDate,
            PublishDate = deepClone ? other.PublishDate?.ToTaskPublishInfo() : other.PublishDate,
            PublishInfo = deepClone ? other.PublishInfo?.ToTaskPublishInfo() : other.PublishInfo
        };
        
        /// <summary>
        /// Selects the type TaskCreateRequest from a IQueryable<TaskCreateRequest>
        /// </summary>
        public static IQueryable<TaskCreateRequest> SelectAsTaskCreateRequest(this IQueryable<TaskCreateRequest> query) => query.Select(other => new TaskCreateRequest() { 
            Recipients = other.Recipients,
            Message = other.Message,
            Data = other.Data,
            InformationDate = other.InformationDate,
            PublishDate = other.PublishDate,
            PublishInfo = other.PublishInfo
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTaskPublishInfo(this TaskPublishInfo item, TaskPublishInfo other, bool deepClone = true) {
            item.Type = (TaskPublishInfo.TypeValue)other.Type;
            item.Value = other.Value;
        }
        
        /// <summary>
        /// Returns a new object of TaskPublishInfo with fileds filled from TaskPublishInfo. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static TaskPublishInfo ToTaskPublishInfo(this TaskPublishInfo other, bool deepClone = true) => new TaskPublishInfo() { 
            Type = (TaskPublishInfo.TypeValue)other.Type,
            Value = other.Value
        };
        
        /// <summary>
        /// Selects the type TaskPublishInfo from a IQueryable<TaskPublishInfo>
        /// </summary>
        public static IQueryable<TaskPublishInfo> SelectAsTaskPublishInfo(this IQueryable<TaskPublishInfo> query) => query.Select(other => new TaskPublishInfo() { 
            Type = (TaskPublishInfo.TypeValue)other.Type,
            Value = other.Value
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestPageableRegistrations(this RestPageableRegistrations item, RestPageableRegistrations other, bool deepClone = true) {
            item.TotalSize = other.TotalSize;
            item.Elements = deepClone ? other.Elements?.Select(value=>value?.ToRestRegistration())?.ToList() : other.Elements;
            item.Headers = deepClone ? other.Headers?.Select(value=>value?.ToWebRegistrationHeader())?.ToList() : other.Headers;
        }
        
        /// <summary>
        /// Returns a new object of RestPageableRegistrations with fileds filled from RestPageableRegistrations. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestPageableRegistrations ToRestPageableRegistrations(this RestPageableRegistrations other, bool deepClone = true) => new RestPageableRegistrations() { 
            TotalSize = other.TotalSize,
            Elements = deepClone ? other.Elements?.Select(value=>value?.ToRestRegistration())?.ToList() : other.Elements,
            Headers = deepClone ? other.Headers?.Select(value=>value?.ToWebRegistrationHeader())?.ToList() : other.Headers
        };
        
        /// <summary>
        /// Selects the type RestPageableRegistrations from a IQueryable<RestPageableRegistrations>
        /// </summary>
        public static IQueryable<RestPageableRegistrations> SelectAsRestPageableRegistrations(this IQueryable<RestPageableRegistrations> query) => query.Select(other => new RestPageableRegistrations() { 
            TotalSize = other.TotalSize,
            Elements = other.Elements,
            Headers = other.Headers
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestRegistration(this RestRegistration item, RestRegistration other, bool deepClone = true) {
            item.Id = other.Id;
            item.Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data;
            item.Info = deepClone ? other.Info?.ToRestRegistrationInfo() : other.Info;
            item.Meta = deepClone ? other.Meta?.ToRestRegistrationMeta() : other.Meta;
            item.MailStatuses = deepClone ? other.MailStatuses?.Select(value=>value?.ToRestRegistrationMailStatus())?.ToList() : other.MailStatuses;
        }
        
        /// <summary>
        /// Returns a new object of RestRegistration with fileds filled from RestRegistration. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestRegistration ToRestRegistration(this RestRegistration other, bool deepClone = true) => new RestRegistration() { 
            Id = other.Id,
            Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data,
            Info = deepClone ? other.Info?.ToRestRegistrationInfo() : other.Info,
            Meta = deepClone ? other.Meta?.ToRestRegistrationMeta() : other.Meta,
            MailStatuses = deepClone ? other.MailStatuses?.Select(value=>value?.ToRestRegistrationMailStatus())?.ToList() : other.MailStatuses
        };
        
        /// <summary>
        /// Selects the type RestRegistration from a IQueryable<RestRegistration>
        /// </summary>
        public static IQueryable<RestRegistration> SelectAsRestRegistration(this IQueryable<RestRegistration> query) => query.Select(other => new RestRegistration() { 
            Id = other.Id,
            Data = other.Data,
            Info = other.Info,
            Meta = other.Meta,
            MailStatuses = other.MailStatuses
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestRegistrationInfo(this RestRegistrationInfo item, RestRegistrationInfo other, bool deepClone = true) {
            item.Date = other.Date;
            item.UserId = other.UserId;
            item.PartnerId = other.PartnerId;
            item.CustomerId = other.CustomerId;
            item.CustomerName = other.CustomerName;
            item.FormVersionId = other.FormVersionId;
            item.FormId = other.FormId;
            item.FormName = other.FormName;
            item.Paid = other.Paid;
            item.Copy = other.Copy;
            item.Price = other.Price;
            item.Credits = other.Credits;
            item.Resends = other.Resends;
            item.ApplicationArtifactVersion = other.ApplicationArtifactVersion;
        }
        
        /// <summary>
        /// Returns a new object of RestRegistrationInfo with fileds filled from RestRegistrationInfo. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestRegistrationInfo ToRestRegistrationInfo(this RestRegistrationInfo other, bool deepClone = true) => new RestRegistrationInfo() { 
            Date = other.Date,
            UserId = other.UserId,
            PartnerId = other.PartnerId,
            CustomerId = other.CustomerId,
            CustomerName = other.CustomerName,
            FormVersionId = other.FormVersionId,
            FormId = other.FormId,
            FormName = other.FormName,
            Paid = other.Paid,
            Copy = other.Copy,
            Price = other.Price,
            Credits = other.Credits,
            Resends = other.Resends,
            ApplicationArtifactVersion = other.ApplicationArtifactVersion
        };
        
        /// <summary>
        /// Selects the type RestRegistrationInfo from a IQueryable<RestRegistrationInfo>
        /// </summary>
        public static IQueryable<RestRegistrationInfo> SelectAsRestRegistrationInfo(this IQueryable<RestRegistrationInfo> query) => query.Select(other => new RestRegistrationInfo() { 
            Date = other.Date,
            UserId = other.UserId,
            PartnerId = other.PartnerId,
            CustomerId = other.CustomerId,
            CustomerName = other.CustomerName,
            FormVersionId = other.FormVersionId,
            FormId = other.FormId,
            FormName = other.FormName,
            Paid = other.Paid,
            Copy = other.Copy,
            Price = other.Price,
            Credits = other.Credits,
            Resends = other.Resends,
            ApplicationArtifactVersion = other.ApplicationArtifactVersion
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestRegistrationMeta(this RestRegistrationMeta item, RestRegistrationMeta other, bool deepClone = true) {
            item.RegistrationDate = other.RegistrationDate;
            item.Guid = other.Guid;
            item.InstructionId = other.InstructionId;
            item.TaskId = other.TaskId;
            item.CompatibilityLevel = other.CompatibilityLevel;
            item.Version = other.Version;
            item.SerialNumber = other.SerialNumber;
            item.HiddenFields = deepClone ? other.HiddenFields?.ToList() : other.HiddenFields;
            item.Location = deepClone ? other.Location?.ToRestRegistrationMetaLocation() : other.Location;
            item.Device = deepClone ? other.Device?.ToRestRegistrationMetaDevice() : other.Device;
        }
        
        /// <summary>
        /// Returns a new object of RestRegistrationMeta with fileds filled from RestRegistrationMeta. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestRegistrationMeta ToRestRegistrationMeta(this RestRegistrationMeta other, bool deepClone = true) => new RestRegistrationMeta() { 
            RegistrationDate = other.RegistrationDate,
            Guid = other.Guid,
            InstructionId = other.InstructionId,
            TaskId = other.TaskId,
            CompatibilityLevel = other.CompatibilityLevel,
            Version = other.Version,
            SerialNumber = other.SerialNumber,
            HiddenFields = deepClone ? other.HiddenFields?.ToList() : other.HiddenFields,
            Location = deepClone ? other.Location?.ToRestRegistrationMetaLocation() : other.Location,
            Device = deepClone ? other.Device?.ToRestRegistrationMetaDevice() : other.Device
        };
        
        /// <summary>
        /// Selects the type RestRegistrationMeta from a IQueryable<RestRegistrationMeta>
        /// </summary>
        public static IQueryable<RestRegistrationMeta> SelectAsRestRegistrationMeta(this IQueryable<RestRegistrationMeta> query) => query.Select(other => new RestRegistrationMeta() { 
            RegistrationDate = other.RegistrationDate,
            Guid = other.Guid,
            InstructionId = other.InstructionId,
            TaskId = other.TaskId,
            CompatibilityLevel = other.CompatibilityLevel,
            Version = other.Version,
            SerialNumber = other.SerialNumber,
            HiddenFields = other.HiddenFields,
            Location = other.Location,
            Device = other.Device
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestRegistrationMetaLocation(this RestRegistrationMetaLocation item, RestRegistrationMetaLocation other, bool deepClone = true) {
            item.Latitude = other.Latitude;
            item.Longitude = other.Longitude;
        }
        
        /// <summary>
        /// Returns a new object of RestRegistrationMetaLocation with fileds filled from RestRegistrationMetaLocation. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestRegistrationMetaLocation ToRestRegistrationMetaLocation(this RestRegistrationMetaLocation other, bool deepClone = true) => new RestRegistrationMetaLocation() { 
            Latitude = other.Latitude,
            Longitude = other.Longitude
        };
        
        /// <summary>
        /// Selects the type RestRegistrationMetaLocation from a IQueryable<RestRegistrationMetaLocation>
        /// </summary>
        public static IQueryable<RestRegistrationMetaLocation> SelectAsRestRegistrationMetaLocation(this IQueryable<RestRegistrationMetaLocation> query) => query.Select(other => new RestRegistrationMetaLocation() { 
            Latitude = other.Latitude,
            Longitude = other.Longitude
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestRegistrationMetaDevice(this RestRegistrationMetaDevice item, RestRegistrationMetaDevice other, bool deepClone = true) {
            item.Uuid = other.Uuid;
            item.Name = other.Name;
            item.Network = other.Network;
            item.UserAgent = other.UserAgent;
            item.AppVersion = other.AppVersion;
        }
        
        /// <summary>
        /// Returns a new object of RestRegistrationMetaDevice with fileds filled from RestRegistrationMetaDevice. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestRegistrationMetaDevice ToRestRegistrationMetaDevice(this RestRegistrationMetaDevice other, bool deepClone = true) => new RestRegistrationMetaDevice() { 
            Uuid = other.Uuid,
            Name = other.Name,
            Network = other.Network,
            UserAgent = other.UserAgent,
            AppVersion = other.AppVersion
        };
        
        /// <summary>
        /// Selects the type RestRegistrationMetaDevice from a IQueryable<RestRegistrationMetaDevice>
        /// </summary>
        public static IQueryable<RestRegistrationMetaDevice> SelectAsRestRegistrationMetaDevice(this IQueryable<RestRegistrationMetaDevice> query) => query.Select(other => new RestRegistrationMetaDevice() { 
            Uuid = other.Uuid,
            Name = other.Name,
            Network = other.Network,
            UserAgent = other.UserAgent,
            AppVersion = other.AppVersion
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestRegistrationMailStatus(this RestRegistrationMailStatus item, RestRegistrationMailStatus other, bool deepClone = true) {
            item.MailIds = deepClone ? other.MailIds?.ToList() : other.MailIds;
            item.PdfFileId = other.PdfFileId;
            item.EmailAddresses = deepClone ? other.EmailAddresses?.ToList() : other.EmailAddresses;
            item.Status = deepClone ? other.Status?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToRestMailSendStatus()) : other.Status;
            item.NotificationId = other.NotificationId;
            item.Attempt = other.Attempt;
        }
        
        /// <summary>
        /// Returns a new object of RestRegistrationMailStatus with fileds filled from RestRegistrationMailStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestRegistrationMailStatus ToRestRegistrationMailStatus(this RestRegistrationMailStatus other, bool deepClone = true) => new RestRegistrationMailStatus() { 
            MailIds = deepClone ? other.MailIds?.ToList() : other.MailIds,
            PdfFileId = other.PdfFileId,
            EmailAddresses = deepClone ? other.EmailAddresses?.ToList() : other.EmailAddresses,
            Status = deepClone ? other.Status?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToRestMailSendStatus()) : other.Status,
            NotificationId = other.NotificationId,
            Attempt = other.Attempt
        };
        
        /// <summary>
        /// Selects the type RestRegistrationMailStatus from a IQueryable<RestRegistrationMailStatus>
        /// </summary>
        public static IQueryable<RestRegistrationMailStatus> SelectAsRestRegistrationMailStatus(this IQueryable<RestRegistrationMailStatus> query) => query.Select(other => new RestRegistrationMailStatus() { 
            MailIds = other.MailIds,
            PdfFileId = other.PdfFileId,
            EmailAddresses = other.EmailAddresses,
            Status = other.Status,
            NotificationId = other.NotificationId,
            Attempt = other.Attempt
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestMailSendStatus(this RestMailSendStatus item, RestMailSendStatus other, bool deepClone = true) {
            item.Email = other.Email;
            item.Transitions = deepClone ? other.Transitions?.Select(value=>value?.ToRestMailTransition())?.ToList() : other.Transitions;
        }
        
        /// <summary>
        /// Returns a new object of RestMailSendStatus with fileds filled from RestMailSendStatus. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestMailSendStatus ToRestMailSendStatus(this RestMailSendStatus other, bool deepClone = true) => new RestMailSendStatus() { 
            Email = other.Email,
            Transitions = deepClone ? other.Transitions?.Select(value=>value?.ToRestMailTransition())?.ToList() : other.Transitions
        };
        
        /// <summary>
        /// Selects the type RestMailSendStatus from a IQueryable<RestMailSendStatus>
        /// </summary>
        public static IQueryable<RestMailSendStatus> SelectAsRestMailSendStatus(this IQueryable<RestMailSendStatus> query) => query.Select(other => new RestMailSendStatus() { 
            Email = other.Email,
            Transitions = other.Transitions
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestMailTransition(this RestMailTransition item, RestMailTransition other, bool deepClone = true) {
            item.Date = other.Date;
            item.Status = other.Status;
            item.RejectReason = other.RejectReason;
            item.BounceDescription = other.BounceDescription;
        }
        
        /// <summary>
        /// Returns a new object of RestMailTransition with fileds filled from RestMailTransition. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestMailTransition ToRestMailTransition(this RestMailTransition other, bool deepClone = true) => new RestMailTransition() { 
            Date = other.Date,
            Status = other.Status,
            RejectReason = other.RejectReason,
            BounceDescription = other.BounceDescription
        };
        
        /// <summary>
        /// Selects the type RestMailTransition from a IQueryable<RestMailTransition>
        /// </summary>
        public static IQueryable<RestMailTransition> SelectAsRestMailTransition(this IQueryable<RestMailTransition> query) => query.Select(other => new RestMailTransition() { 
            Date = other.Date,
            Status = other.Status,
            RejectReason = other.RejectReason,
            BounceDescription = other.BounceDescription
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithWebRegistrationHeader(this WebRegistrationHeader item, WebRegistrationHeader other, bool deepClone = true) {
            item.Id = other.Id;
            item.Label = other.Label;
        }
        
        /// <summary>
        /// Returns a new object of WebRegistrationHeader with fileds filled from WebRegistrationHeader. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static WebRegistrationHeader ToWebRegistrationHeader(this WebRegistrationHeader other, bool deepClone = true) => new WebRegistrationHeader() { 
            Id = other.Id,
            Label = other.Label
        };
        
        /// <summary>
        /// Selects the type WebRegistrationHeader from a IQueryable<WebRegistrationHeader>
        /// </summary>
        public static IQueryable<WebRegistrationHeader> SelectAsWebRegistrationHeader(this IQueryable<WebRegistrationHeader> query) => query.Select(other => new WebRegistrationHeader() { 
            Id = other.Id,
            Label = other.Label
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExportRequest(this ExportRequest item, ExportRequest other, bool deepClone = true) {
            item.ExporterType = (ExportRequest.ExporterTypeValue)other.ExporterType;
            item.SubmissionIds = deepClone ? other.SubmissionIds?.ToList() : other.SubmissionIds;
            item.ExportFields = deepClone ? other.ExportFields?.Select(value=>value?.ToExportField())?.ToList() : other.ExportFields;
            item.MailOnFinish = deepClone ? other.MailOnFinish?.ToList() : other.MailOnFinish;
            item.Options = deepClone ? other.Options?.ToExportOptions() : other.Options;
            item.FilterQueries = deepClone ? other.FilterQueries?.Select(value=>value?.ToFilterQuery())?.ToList() : other.FilterQueries;
        }
        
        /// <summary>
        /// Returns a new object of ExportRequest with fileds filled from ExportRequest. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ExportRequest ToExportRequest(this ExportRequest other, bool deepClone = true) => new ExportRequest() { 
            ExporterType = (ExportRequest.ExporterTypeValue)other.ExporterType,
            SubmissionIds = deepClone ? other.SubmissionIds?.ToList() : other.SubmissionIds,
            ExportFields = deepClone ? other.ExportFields?.Select(value=>value?.ToExportField())?.ToList() : other.ExportFields,
            MailOnFinish = deepClone ? other.MailOnFinish?.ToList() : other.MailOnFinish,
            Options = deepClone ? other.Options?.ToExportOptions() : other.Options,
            FilterQueries = deepClone ? other.FilterQueries?.Select(value=>value?.ToFilterQuery())?.ToList() : other.FilterQueries
        };
        
        /// <summary>
        /// Selects the type ExportRequest from a IQueryable<ExportRequest>
        /// </summary>
        public static IQueryable<ExportRequest> SelectAsExportRequest(this IQueryable<ExportRequest> query) => query.Select(other => new ExportRequest() { 
            ExporterType = (ExportRequest.ExporterTypeValue)other.ExporterType,
            SubmissionIds = other.SubmissionIds,
            ExportFields = other.ExportFields,
            MailOnFinish = other.MailOnFinish,
            Options = other.Options,
            FilterQueries = other.FilterQueries
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExportField(this ExportField item, ExportField other, bool deepClone = true) {
            item.Name = other.Name;
            item.DataName = other.DataName;
            item.ExportFieldType = other.ExportFieldType == null ? null : (ExportField.ExportFieldTypeValue)other.ExportFieldType;
            item.Fields = deepClone ? other.Fields?.Select(value=>value?.ToExportField())?.ToList() : other.Fields;
        }
        
        /// <summary>
        /// Returns a new object of ExportField with fileds filled from ExportField. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ExportField ToExportField(this ExportField other, bool deepClone = true) => new ExportField() { 
            Name = other.Name,
            DataName = other.DataName,
            ExportFieldType = other.ExportFieldType == null ? null : (ExportField.ExportFieldTypeValue)other.ExportFieldType,
            Fields = deepClone ? other.Fields?.Select(value=>value?.ToExportField())?.ToList() : other.Fields
        };
        
        /// <summary>
        /// Selects the type ExportField from a IQueryable<ExportField>
        /// </summary>
        public static IQueryable<ExportField> SelectAsExportField(this IQueryable<ExportField> query) => query.Select(other => new ExportField() { 
            Name = other.Name,
            DataName = other.DataName,
            ExportFieldType = other.ExportFieldType == null ? null : (ExportField.ExportFieldTypeValue)other.ExportFieldType,
            Fields = other.Fields
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExportOptions(this ExportOptions item, ExportOptions other, bool deepClone = true) {
            item.Timezone = other.Timezone;
            item.IncludeFiles = other.IncludeFiles;
            item.ExcelSingleSheet = other.ExcelSingleSheet;
            item.LanguageCode = (ExportOptions.LanguageCodeValue)other.LanguageCode;
        }
        
        /// <summary>
        /// Returns a new object of ExportOptions with fileds filled from ExportOptions. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ExportOptions ToExportOptions(this ExportOptions other, bool deepClone = true) => new ExportOptions() { 
            Timezone = other.Timezone,
            IncludeFiles = other.IncludeFiles,
            ExcelSingleSheet = other.ExcelSingleSheet,
            LanguageCode = (ExportOptions.LanguageCodeValue)other.LanguageCode
        };
        
        /// <summary>
        /// Selects the type ExportOptions from a IQueryable<ExportOptions>
        /// </summary>
        public static IQueryable<ExportOptions> SelectAsExportOptions(this IQueryable<ExportOptions> query) => query.Select(other => new ExportOptions() { 
            Timezone = other.Timezone,
            IncludeFiles = other.IncludeFiles,
            ExcelSingleSheet = other.ExcelSingleSheet,
            LanguageCode = (ExportOptions.LanguageCodeValue)other.LanguageCode
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithExportScheduledResponse(this ExportScheduledResponse item, ExportScheduledResponse other, bool deepClone = true) {
            item.Id = other.Id;
        }
        
        /// <summary>
        /// Returns a new object of ExportScheduledResponse with fileds filled from ExportScheduledResponse. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ExportScheduledResponse ToExportScheduledResponse(this ExportScheduledResponse other, bool deepClone = true) => new ExportScheduledResponse() { 
            Id = other.Id
        };
        
        /// <summary>
        /// Selects the type ExportScheduledResponse from a IQueryable<ExportScheduledResponse>
        /// </summary>
        public static IQueryable<ExportScheduledResponse> SelectAsExportScheduledResponse(this IQueryable<ExportScheduledResponse> query) => query.Select(other => new ExportScheduledResponse() { 
            Id = other.Id
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestGrantChange(this RestGrantChange item, RestGrantChange other, bool deepClone = true) {
            item.Operation = (RestGrantChange.OperationValue)other.Operation;
            item.RoleId = other.RoleId;
            item.ResourceId = other.ResourceId;
            item.ResourceType = (RestGrantChange.ResourceTypeValue)other.ResourceType;
        }
        
        /// <summary>
        /// Returns a new object of RestGrantChange with fileds filled from RestGrantChange. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestGrantChange ToRestGrantChange(this RestGrantChange other, bool deepClone = true) => new RestGrantChange() { 
            Operation = (RestGrantChange.OperationValue)other.Operation,
            RoleId = other.RoleId,
            ResourceId = other.ResourceId,
            ResourceType = (RestGrantChange.ResourceTypeValue)other.ResourceType
        };
        
        /// <summary>
        /// Selects the type RestGrantChange from a IQueryable<RestGrantChange>
        /// </summary>
        public static IQueryable<RestGrantChange> SelectAsRestGrantChange(this IQueryable<RestGrantChange> query) => query.Select(other => new RestGrantChange() { 
            Operation = (RestGrantChange.OperationValue)other.Operation,
            RoleId = other.RoleId,
            ResourceId = other.ResourceId,
            ResourceType = (RestGrantChange.ResourceTypeValue)other.ResourceType
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithGroupUser(this GroupUser item, GroupUser other, bool deepClone = true) {
            item.Id = other.Id;
            item.Username = other.Username;
            item.FirstName = other.FirstName;
            item.LastName = other.LastName;
            item.ExternallyManaged = other.ExternallyManaged;
            item.Disabled = other.Disabled;
        }
        
        /// <summary>
        /// Returns a new object of GroupUser with fileds filled from GroupUser. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static GroupUser ToGroupUser(this GroupUser other, bool deepClone = true) => new GroupUser() { 
            Id = other.Id,
            Username = other.Username,
            FirstName = other.FirstName,
            LastName = other.LastName,
            ExternallyManaged = other.ExternallyManaged,
            Disabled = other.Disabled
        };
        
        /// <summary>
        /// Selects the type GroupUser from a IQueryable<GroupUser>
        /// </summary>
        public static IQueryable<GroupUser> SelectAsGroupUser(this IQueryable<GroupUser> query) => query.Select(other => new GroupUser() { 
            Id = other.Id,
            Username = other.Username,
            FirstName = other.FirstName,
            LastName = other.LastName,
            ExternallyManaged = other.ExternallyManaged,
            Disabled = other.Disabled
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithCustomer(this Customer item, Customer other, bool deepClone = true) {
            item.Id = other.Id;
            item.CustomerId = other.CustomerId;
            item.Name = other.Name;
            item.LogoAssetId = other.LogoAssetId;
            item.Settings = deepClone ? other.Settings?.ToRestCustomerSettings() : other.Settings;
            item.Meta = deepClone ? other.Meta?.ToRestCustomerMeta() : other.Meta;
        }
        
        /// <summary>
        /// Returns a new object of Customer with fileds filled from Customer. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Customer ToCustomer(this Customer other, bool deepClone = true) => new Customer() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            Name = other.Name,
            LogoAssetId = other.LogoAssetId,
            Settings = deepClone ? other.Settings?.ToRestCustomerSettings() : other.Settings,
            Meta = deepClone ? other.Meta?.ToRestCustomerMeta() : other.Meta
        };
        
        /// <summary>
        /// Selects the type Customer from a IQueryable<Customer>
        /// </summary>
        public static IQueryable<Customer> SelectAsCustomer(this IQueryable<Customer> query) => query.Select(other => new Customer() { 
            Id = other.Id,
            CustomerId = other.CustomerId,
            Name = other.Name,
            LogoAssetId = other.LogoAssetId,
            Settings = other.Settings,
            Meta = other.Meta
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestCustomerSettings(this RestCustomerSettings item, RestCustomerSettings other, bool deepClone = true) {
            item.DateFormat = other.DateFormat == null ? null : (RestCustomerSettings.DateFormatValue)other.DateFormat;
            item.Segment = other.Segment == null ? null : (RestCustomerSettings.SegmentValue)other.Segment;
            item.OtherSegment = other.OtherSegment;
            item.Type = other.Type;
        }
        
        /// <summary>
        /// Returns a new object of RestCustomerSettings with fileds filled from RestCustomerSettings. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestCustomerSettings ToRestCustomerSettings(this RestCustomerSettings other, bool deepClone = true) => new RestCustomerSettings() { 
            DateFormat = other.DateFormat == null ? null : (RestCustomerSettings.DateFormatValue)other.DateFormat,
            Segment = other.Segment == null ? null : (RestCustomerSettings.SegmentValue)other.Segment,
            OtherSegment = other.OtherSegment,
            Type = other.Type
        };
        
        /// <summary>
        /// Selects the type RestCustomerSettings from a IQueryable<RestCustomerSettings>
        /// </summary>
        public static IQueryable<RestCustomerSettings> SelectAsRestCustomerSettings(this IQueryable<RestCustomerSettings> query) => query.Select(other => new RestCustomerSettings() { 
            DateFormat = other.DateFormat == null ? null : (RestCustomerSettings.DateFormatValue)other.DateFormat,
            Segment = other.Segment == null ? null : (RestCustomerSettings.SegmentValue)other.Segment,
            OtherSegment = other.OtherSegment,
            Type = other.Type
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithUser(this User item, User other, bool deepClone = true) {
            item.Id = other.Id;
            item.Username = other.Username;
            item.EmailAddress = other.EmailAddress;
            item.Settings = deepClone ? other.Settings?.ToRestUserSettings() : other.Settings;
            item.EmailValidated = other.EmailValidated;
            item.Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants;
            item.Groups = deepClone ? other.Groups?.ToList() : other.Groups;
        }
        
        /// <summary>
        /// Returns a new object of User with fileds filled from User. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static User ToUser(this User other, bool deepClone = true) => new User() { 
            Id = other.Id,
            Username = other.Username,
            EmailAddress = other.EmailAddress,
            Settings = deepClone ? other.Settings?.ToRestUserSettings() : other.Settings,
            EmailValidated = other.EmailValidated,
            Grants = deepClone ? other.Grants?.Select(value=>value?.ToGrant())?.ToList() : other.Grants,
            Groups = deepClone ? other.Groups?.ToList() : other.Groups
        };
        
        /// <summary>
        /// Selects the type User from a IQueryable<User>
        /// </summary>
        public static IQueryable<User> SelectAsUser(this IQueryable<User> query) => query.Select(other => new User() { 
            Id = other.Id,
            Username = other.Username,
            EmailAddress = other.EmailAddress,
            Settings = other.Settings,
            EmailValidated = other.EmailValidated,
            Grants = other.Grants,
            Groups = other.Groups
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRestUserSettings(this RestUserSettings item, RestUserSettings other, bool deepClone = true) {
            item.FirstName = other.FirstName;
            item.LastName = other.LastName;
            item.Language = (RestUserSettings.LanguageValue)other.Language;
            item.PhoneNumber = other.PhoneNumber;
            item.ReceiveNewsLetter = other.ReceiveNewsLetter;
            item.FinishedTour = other.FinishedTour;
            item.TimeZone = deepClone ? other.TimeZone?.DeepClone() : other.TimeZone;
        }
        
        /// <summary>
        /// Returns a new object of RestUserSettings with fileds filled from RestUserSettings. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static RestUserSettings ToRestUserSettings(this RestUserSettings other, bool deepClone = true) => new RestUserSettings() { 
            FirstName = other.FirstName,
            LastName = other.LastName,
            Language = (RestUserSettings.LanguageValue)other.Language,
            PhoneNumber = other.PhoneNumber,
            ReceiveNewsLetter = other.ReceiveNewsLetter,
            FinishedTour = other.FinishedTour,
            TimeZone = deepClone ? other.TimeZone?.DeepClone() : other.TimeZone
        };
        
        /// <summary>
        /// Selects the type RestUserSettings from a IQueryable<RestUserSettings>
        /// </summary>
        public static IQueryable<RestUserSettings> SelectAsRestUserSettings(this IQueryable<RestUserSettings> query) => query.Select(other => new RestUserSettings() { 
            FirstName = other.FirstName,
            LastName = other.LastName,
            Language = (RestUserSettings.LanguageValue)other.Language,
            PhoneNumber = other.PhoneNumber,
            ReceiveNewsLetter = other.ReceiveNewsLetter,
            FinishedTour = other.FinishedTour,
            TimeZone = other.TimeZone
        });
    }
}
