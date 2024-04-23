#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFormDto(this FormDto item, FormDto other, bool deepClone = true) {
            item.Id = other.Id;
            item.PublishedVersion = deepClone ? other.PublishedVersion?.ToFormPublishedVersionDto() : other.PublishedVersion;
            item.Meta = deepClone ? other.Meta?.ToFormMetadataDto() : other.Meta;
            item.Status = other.Status == null ? null : (FormDto.StatusValue)other.Status;
            item.Scope = other.Scope == null ? null : (FormDto.ScopeValue)other.Scope;
        }
        
        /// <summary>
        /// Returns a new object of FormDto with fileds filled from FormDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FormDto ToFormDto(this FormDto other, bool deepClone = true) => new FormDto() { 
            Id = other.Id,
            PublishedVersion = deepClone ? other.PublishedVersion?.ToFormPublishedVersionDto() : other.PublishedVersion,
            Meta = deepClone ? other.Meta?.ToFormMetadataDto() : other.Meta,
            Status = other.Status == null ? null : (FormDto.StatusValue)other.Status,
            Scope = other.Scope == null ? null : (FormDto.ScopeValue)other.Scope
        };
        
        /// <summary>
        /// Selects the type FormDto from a IQueryable<FormDto>
        /// </summary>
        public static IQueryable<FormDto> SelectAsFormDto(this IQueryable<FormDto> query) => query.Select(other => new FormDto() { 
            Id = other.Id,
            PublishedVersion = other.PublishedVersion,
            Meta = other.Meta,
            Status = other.Status == null ? null : (FormDto.StatusValue)other.Status,
            Scope = other.Scope == null ? null : (FormDto.ScopeValue)other.Scope
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFormMetadataDto(this FormMetadataDto item, FormMetadataDto other, bool deepClone = true) {
            item.Name = other.Name;
            item.Icon = other.Icon;
            item.IconColor = other.IconColor == null ? null : (FormMetadataDto.IconColorValue)other.IconColor;
            item.Description = other.Description;
            item.Language = other.Language;
            item.ViewId = other.ViewId;
            item.Tags = deepClone ? other.Tags?.ToList() : other.Tags;
            item.TemplateId = other.TemplateId;
            item.ArchivedOn = other.ArchivedOn;
            item.ArchivedBy = other.ArchivedBy;
        }
        
        /// <summary>
        /// Returns a new object of FormMetadataDto with fileds filled from FormMetadataDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FormMetadataDto ToFormMetadataDto(this FormMetadataDto other, bool deepClone = true) => new FormMetadataDto() { 
            Name = other.Name,
            Icon = other.Icon,
            IconColor = other.IconColor == null ? null : (FormMetadataDto.IconColorValue)other.IconColor,
            Description = other.Description,
            Language = other.Language,
            ViewId = other.ViewId,
            Tags = deepClone ? other.Tags?.ToList() : other.Tags,
            TemplateId = other.TemplateId,
            ArchivedOn = other.ArchivedOn,
            ArchivedBy = other.ArchivedBy
        };
        
        /// <summary>
        /// Selects the type FormMetadataDto from a IQueryable<FormMetadataDto>
        /// </summary>
        public static IQueryable<FormMetadataDto> SelectAsFormMetadataDto(this IQueryable<FormMetadataDto> query) => query.Select(other => new FormMetadataDto() { 
            Name = other.Name,
            Icon = other.Icon,
            IconColor = other.IconColor == null ? null : (FormMetadataDto.IconColorValue)other.IconColor,
            Description = other.Description,
            Language = other.Language,
            ViewId = other.ViewId,
            Tags = other.Tags,
            TemplateId = other.TemplateId,
            ArchivedOn = other.ArchivedOn,
            ArchivedBy = other.ArchivedBy
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFormPublishedVersionDto(this FormPublishedVersionDto item, FormPublishedVersionDto other, bool deepClone = true) {
            item.FormVersion = other.FormVersion;
            item.PublishedDate = other.PublishedDate;
            item.PublishedBy = other.PublishedBy;
            item.Remarks = other.Remarks;
        }
        
        /// <summary>
        /// Returns a new object of FormPublishedVersionDto with fileds filled from FormPublishedVersionDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FormPublishedVersionDto ToFormPublishedVersionDto(this FormPublishedVersionDto other, bool deepClone = true) => new FormPublishedVersionDto() { 
            FormVersion = other.FormVersion,
            PublishedDate = other.PublishedDate,
            PublishedBy = other.PublishedBy,
            Remarks = other.Remarks
        };
        
        /// <summary>
        /// Selects the type FormPublishedVersionDto from a IQueryable<FormPublishedVersionDto>
        /// </summary>
        public static IQueryable<FormPublishedVersionDto> SelectAsFormPublishedVersionDto(this IQueryable<FormPublishedVersionDto> query) => query.Select(other => new FormPublishedVersionDto() { 
            FormVersion = other.FormVersion,
            PublishedDate = other.PublishedDate,
            PublishedBy = other.PublishedBy,
            Remarks = other.Remarks
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithAction(this Action item, Action other, bool deepClone = true) {
            item.FieldUid = other.FieldUid;
            item.Key = other.Key;
            item.Value = deepClone ? other.Value?.DeepClone() : other.Value;
        }
        
        /// <summary>
        /// Returns a new object of Action with fileds filled from Action. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Action ToAction(this Action other, bool deepClone = true) => new Action() { 
            FieldUid = other.FieldUid,
            Key = other.Key,
            Value = deepClone ? other.Value?.DeepClone() : other.Value
        };
        
        /// <summary>
        /// Selects the type Action from a IQueryable<Action>
        /// </summary>
        public static IQueryable<Action> SelectAsAction(this IQueryable<Action> query) => query.Select(other => new Action() { 
            FieldUid = other.FieldUid,
            Key = other.Key,
            Value = other.Value
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithCondition(this Condition item, Condition other, bool deepClone = true) {
            item.Type = other.Type == null ? null : (Condition.TypeValue)other.Type;
            item.FieldUid = other.FieldUid;
            item.FieldObjectKey = other.FieldObjectKey;
            item.Key = other.Key;
            item.Value = deepClone ? other.Value?.DeepClone() : other.Value;
        }
        
        /// <summary>
        /// Returns a new object of Condition with fileds filled from Condition. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Condition ToCondition(this Condition other, bool deepClone = true) => new Condition() { 
            Type = other.Type == null ? null : (Condition.TypeValue)other.Type,
            FieldUid = other.FieldUid,
            FieldObjectKey = other.FieldObjectKey,
            Key = other.Key,
            Value = deepClone ? other.Value?.DeepClone() : other.Value
        };
        
        /// <summary>
        /// Selects the type Condition from a IQueryable<Condition>
        /// </summary>
        public static IQueryable<Condition> SelectAsCondition(this IQueryable<Condition> query) => query.Select(other => new Condition() { 
            Type = other.Type == null ? null : (Condition.TypeValue)other.Type,
            FieldUid = other.FieldUid,
            FieldObjectKey = other.FieldObjectKey,
            Key = other.Key,
            Value = other.Value
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithDependency(this Dependency item, Dependency other, bool deepClone = true) {
            item.Type = other.Type == null ? null : (Dependency.TypeValue)other.Type;
            item.Value = other.Value;
        }
        
        /// <summary>
        /// Returns a new object of Dependency with fileds filled from Dependency. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Dependency ToDependency(this Dependency other, bool deepClone = true) => new Dependency() { 
            Type = other.Type == null ? null : (Dependency.TypeValue)other.Type,
            Value = other.Value
        };
        
        /// <summary>
        /// Selects the type Dependency from a IQueryable<Dependency>
        /// </summary>
        public static IQueryable<Dependency> SelectAsDependency(this IQueryable<Dependency> query) => query.Select(other => new Dependency() { 
            Type = other.Type == null ? null : (Dependency.TypeValue)other.Type,
            Value = other.Value
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithField(this Field item, Field other, bool deepClone = true) {
            item.Uid = other.Uid;
            item.Widget = other.Widget;
            item.Properties = deepClone ? other.Properties?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Properties;
        }
        
        /// <summary>
        /// Returns a new object of Field with fileds filled from Field. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Field ToField(this Field other, bool deepClone = true) => new Field() { 
            Uid = other.Uid,
            Widget = other.Widget,
            Properties = deepClone ? other.Properties?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Properties
        };
        
        /// <summary>
        /// Selects the type Field from a IQueryable<Field>
        /// </summary>
        public static IQueryable<Field> SelectAsField(this IQueryable<Field> query) => query.Select(other => new Field() { 
            Uid = other.Uid,
            Widget = other.Widget,
            Properties = other.Properties
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFormVersionDto(this FormVersionDto item, FormVersionDto other, bool deepClone = true) {
            item.Id = other.Id;
            item.FormId = other.FormId;
            item.Fields = deepClone ? other.Fields?.Select(value=>value?.ToField())?.ToList() : other.Fields;
            item.Rules = deepClone ? other.Rules?.Select(value=>value?.ToRule())?.ToList() : other.Rules;
            item.Triggers = deepClone ? other.Triggers?.Select(value=>value?.ToTrigger())?.ToList() : other.Triggers;
            item.Integrations = deepClone ? other.Integrations?.Select(value=>value?.ToIntegrationConfiguration())?.ToList() : other.Integrations;
            item.Dependencies = deepClone ? other.Dependencies?.Select(value=>value?.ToDependency())?.ToList() : other.Dependencies;
            item.FieldProperties = deepClone ? other.FieldProperties?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.FieldProperties;
            item.Meta = deepClone ? other.Meta?.ToFormVersionMetadata() : other.Meta;
            item.Settings = deepClone ? other.Settings?.ToSettings() : other.Settings;
            item.Theme = deepClone ? other.Theme?.ToThemeDto() : other.Theme;
        }
        
        /// <summary>
        /// Returns a new object of FormVersionDto with fileds filled from FormVersionDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FormVersionDto ToFormVersionDto(this FormVersionDto other, bool deepClone = true) => new FormVersionDto() { 
            Id = other.Id,
            FormId = other.FormId,
            Fields = deepClone ? other.Fields?.Select(value=>value?.ToField())?.ToList() : other.Fields,
            Rules = deepClone ? other.Rules?.Select(value=>value?.ToRule())?.ToList() : other.Rules,
            Triggers = deepClone ? other.Triggers?.Select(value=>value?.ToTrigger())?.ToList() : other.Triggers,
            Integrations = deepClone ? other.Integrations?.Select(value=>value?.ToIntegrationConfiguration())?.ToList() : other.Integrations,
            Dependencies = deepClone ? other.Dependencies?.Select(value=>value?.ToDependency())?.ToList() : other.Dependencies,
            FieldProperties = deepClone ? other.FieldProperties?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.FieldProperties,
            Meta = deepClone ? other.Meta?.ToFormVersionMetadata() : other.Meta,
            Settings = deepClone ? other.Settings?.ToSettings() : other.Settings,
            Theme = deepClone ? other.Theme?.ToThemeDto() : other.Theme
        };
        
        /// <summary>
        /// Selects the type FormVersionDto from a IQueryable<FormVersionDto>
        /// </summary>
        public static IQueryable<FormVersionDto> SelectAsFormVersionDto(this IQueryable<FormVersionDto> query) => query.Select(other => new FormVersionDto() { 
            Id = other.Id,
            FormId = other.FormId,
            Fields = other.Fields,
            Rules = other.Rules,
            Triggers = other.Triggers,
            Integrations = other.Integrations,
            Dependencies = other.Dependencies,
            FieldProperties = other.FieldProperties,
            Meta = other.Meta,
            Settings = other.Settings,
            Theme = other.Theme
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFormVersionMetadata(this FormVersionMetadata item, FormVersionMetadata other, bool deepClone = true) {
            item.Created = other.Created;
            item.CreatedBy = other.CreatedBy;
            item.LastUpdated = other.LastUpdated;
            item.LastUpdatedBy = other.LastUpdatedBy;
            item.Status = other.Status == null ? null : (FormVersionMetadata.StatusValue)other.Status;
        }
        
        /// <summary>
        /// Returns a new object of FormVersionMetadata with fileds filled from FormVersionMetadata. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FormVersionMetadata ToFormVersionMetadata(this FormVersionMetadata other, bool deepClone = true) => new FormVersionMetadata() { 
            Created = other.Created,
            CreatedBy = other.CreatedBy,
            LastUpdated = other.LastUpdated,
            LastUpdatedBy = other.LastUpdatedBy,
            Status = other.Status == null ? null : (FormVersionMetadata.StatusValue)other.Status
        };
        
        /// <summary>
        /// Selects the type FormVersionMetadata from a IQueryable<FormVersionMetadata>
        /// </summary>
        public static IQueryable<FormVersionMetadata> SelectAsFormVersionMetadata(this IQueryable<FormVersionMetadata> query) => query.Select(other => new FormVersionMetadata() { 
            Created = other.Created,
            CreatedBy = other.CreatedBy,
            LastUpdated = other.LastUpdated,
            LastUpdatedBy = other.LastUpdatedBy,
            Status = other.Status == null ? null : (FormVersionMetadata.StatusValue)other.Status
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithIntegrationConfiguration(this IntegrationConfiguration item, IntegrationConfiguration other, bool deepClone = true) {
            item.Uid = other.Uid;
            item.Key = other.Key;
            item.Namespace = other.Namespace;
            item.Name = other.Name;
            item.Version = other.Version;
            item.Configuration = deepClone ? other.Configuration?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Configuration;
        }
        
        /// <summary>
        /// Returns a new object of IntegrationConfiguration with fileds filled from IntegrationConfiguration. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static IntegrationConfiguration ToIntegrationConfiguration(this IntegrationConfiguration other, bool deepClone = true) => new IntegrationConfiguration() { 
            Uid = other.Uid,
            Key = other.Key,
            Namespace = other.Namespace,
            Name = other.Name,
            Version = other.Version,
            Configuration = deepClone ? other.Configuration?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Configuration
        };
        
        /// <summary>
        /// Selects the type IntegrationConfiguration from a IQueryable<IntegrationConfiguration>
        /// </summary>
        public static IQueryable<IntegrationConfiguration> SelectAsIntegrationConfiguration(this IQueryable<IntegrationConfiguration> query) => query.Select(other => new IntegrationConfiguration() { 
            Uid = other.Uid,
            Key = other.Key,
            Namespace = other.Namespace,
            Name = other.Name,
            Version = other.Version,
            Configuration = other.Configuration
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithRule(this Rule item, Rule other, bool deepClone = true) {
            item.Name = other.Name;
            item.Type = other.Type == null ? null : (Rule.TypeValue)other.Type;
            item.Conditions = deepClone ? other.Conditions?.Select(value=>value?.ToCondition())?.ToList() : other.Conditions;
            item.Actions = deepClone ? other.Actions?.Select(value=>value?.ToAction())?.ToList() : other.Actions;
        }
        
        /// <summary>
        /// Returns a new object of Rule with fileds filled from Rule. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Rule ToRule(this Rule other, bool deepClone = true) => new Rule() { 
            Name = other.Name,
            Type = other.Type == null ? null : (Rule.TypeValue)other.Type,
            Conditions = deepClone ? other.Conditions?.Select(value=>value?.ToCondition())?.ToList() : other.Conditions,
            Actions = deepClone ? other.Actions?.Select(value=>value?.ToAction())?.ToList() : other.Actions
        };
        
        /// <summary>
        /// Selects the type Rule from a IQueryable<Rule>
        /// </summary>
        public static IQueryable<Rule> SelectAsRule(this IQueryable<Rule> query) => query.Select(other => new Rule() { 
            Name = other.Name,
            Type = other.Type == null ? null : (Rule.TypeValue)other.Type,
            Conditions = other.Conditions,
            Actions = other.Actions
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSearchSettings(this SearchSettings item, SearchSettings other, bool deepClone = true) {
            item.Enabled = other.Enabled;
            item.OnlyForCurrentUser = other.OnlyForCurrentUser;
            item.Fields = deepClone ? other.Fields?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Fields;
            item.FilteringEnabled = other.FilteringEnabled;
            item.FilteredFields = deepClone ? other.FilteredFields?.ToList() : other.FilteredFields;
        }
        
        /// <summary>
        /// Returns a new object of SearchSettings with fileds filled from SearchSettings. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static SearchSettings ToSearchSettings(this SearchSettings other, bool deepClone = true) => new SearchSettings() { 
            Enabled = other.Enabled,
            OnlyForCurrentUser = other.OnlyForCurrentUser,
            Fields = deepClone ? other.Fields?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Fields,
            FilteringEnabled = other.FilteringEnabled,
            FilteredFields = deepClone ? other.FilteredFields?.ToList() : other.FilteredFields
        };
        
        /// <summary>
        /// Selects the type SearchSettings from a IQueryable<SearchSettings>
        /// </summary>
        public static IQueryable<SearchSettings> SelectAsSearchSettings(this IQueryable<SearchSettings> query) => query.Select(other => new SearchSettings() { 
            Enabled = other.Enabled,
            OnlyForCurrentUser = other.OnlyForCurrentUser,
            Fields = other.Fields,
            FilteringEnabled = other.FilteringEnabled,
            FilteredFields = other.FilteredFields
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSettings(this Settings item, Settings other, bool deepClone = true) {
            item.Interaction = other.Interaction == null ? null : (Settings.InteractionValue)other.Interaction;
            item.SaveMode = other.SaveMode == null ? null : (Settings.SaveModeValue)other.SaveMode;
            item.SearchSettings = deepClone ? other.SearchSettings?.ToSearchSettings() : other.SearchSettings;
            item.Icon = other.Icon;
            item.ItemHtml = other.ItemHtml;
        }
        
        /// <summary>
        /// Returns a new object of Settings with fileds filled from Settings. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Settings ToSettings(this Settings other, bool deepClone = true) => new Settings() { 
            Interaction = other.Interaction == null ? null : (Settings.InteractionValue)other.Interaction,
            SaveMode = other.SaveMode == null ? null : (Settings.SaveModeValue)other.SaveMode,
            SearchSettings = deepClone ? other.SearchSettings?.ToSearchSettings() : other.SearchSettings,
            Icon = other.Icon,
            ItemHtml = other.ItemHtml
        };
        
        /// <summary>
        /// Selects the type Settings from a IQueryable<Settings>
        /// </summary>
        public static IQueryable<Settings> SelectAsSettings(this IQueryable<Settings> query) => query.Select(other => new Settings() { 
            Interaction = other.Interaction == null ? null : (Settings.InteractionValue)other.Interaction,
            SaveMode = other.SaveMode == null ? null : (Settings.SaveModeValue)other.SaveMode,
            SearchSettings = other.SearchSettings,
            Icon = other.Icon,
            ItemHtml = other.ItemHtml
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithThemeColors(this ThemeColors item, ThemeColors other, bool deepClone = true) {
            item.Background = other.Background;
            item.Button = other.Button;
            item.SaveButton = other.SaveButton;
            item.Widget = other.Widget;
            item.Bar = other.Bar;
        }
        
        /// <summary>
        /// Returns a new object of ThemeColors with fileds filled from ThemeColors. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ThemeColors ToThemeColors(this ThemeColors other, bool deepClone = true) => new ThemeColors() { 
            Background = other.Background,
            Button = other.Button,
            SaveButton = other.SaveButton,
            Widget = other.Widget,
            Bar = other.Bar
        };
        
        /// <summary>
        /// Selects the type ThemeColors from a IQueryable<ThemeColors>
        /// </summary>
        public static IQueryable<ThemeColors> SelectAsThemeColors(this IQueryable<ThemeColors> query) => query.Select(other => new ThemeColors() { 
            Background = other.Background,
            Button = other.Button,
            SaveButton = other.SaveButton,
            Widget = other.Widget,
            Bar = other.Bar
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithThemeDto(this ThemeDto item, ThemeDto other, bool deepClone = true) {
            item.Id = other.Id;
            item.System = other.System;
            item.Name = other.Name;
            item.Colors = deepClone ? other.Colors?.ToThemeColors() : other.Colors;
            item.DefaultTheme = other.DefaultTheme;
        }
        
        /// <summary>
        /// Returns a new object of ThemeDto with fileds filled from ThemeDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static ThemeDto ToThemeDto(this ThemeDto other, bool deepClone = true) => new ThemeDto() { 
            Id = other.Id,
            System = other.System,
            Name = other.Name,
            Colors = deepClone ? other.Colors?.ToThemeColors() : other.Colors,
            DefaultTheme = other.DefaultTheme
        };
        
        /// <summary>
        /// Selects the type ThemeDto from a IQueryable<ThemeDto>
        /// </summary>
        public static IQueryable<ThemeDto> SelectAsThemeDto(this IQueryable<ThemeDto> query) => query.Select(other => new ThemeDto() { 
            Id = other.Id,
            System = other.System,
            Name = other.Name,
            Colors = other.Colors,
            DefaultTheme = other.DefaultTheme
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTrigger(this Trigger item, Trigger other, bool deepClone = true) {
            item.Type = other.Type;
            item.Name = other.Name;
            item.StaticRecipients = deepClone ? other.StaticRecipients?.ToList() : other.StaticRecipients;
            item.DynamicRecipients = deepClone ? other.DynamicRecipients?.ToList() : other.DynamicRecipients;
            item.CarbonCopyRecipients = deepClone ? other.CarbonCopyRecipients?.ToList() : other.CarbonCopyRecipients;
            item.BlindCarbonCopyRecipients = deepClone ? other.BlindCarbonCopyRecipients?.ToList() : other.BlindCarbonCopyRecipients;
            item.Subject = other.Subject;
            item.Content = other.Content;
            item.PdfContent = other.PdfContent;
            item.PdfFilename = other.PdfFilename;
            item.FromName = other.FromName;
            item.ReplyTo = other.ReplyTo;
            item.PdfHeaderLogoResourceId = other.PdfHeaderLogoResourceId;
            item.Configuration = deepClone ? other.Configuration?.ToTriggerConfiguration() : other.Configuration;
        }
        
        /// <summary>
        /// Returns a new object of Trigger with fileds filled from Trigger. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Trigger ToTrigger(this Trigger other, bool deepClone = true) => new Trigger() { 
            Type = other.Type,
            Name = other.Name,
            StaticRecipients = deepClone ? other.StaticRecipients?.ToList() : other.StaticRecipients,
            DynamicRecipients = deepClone ? other.DynamicRecipients?.ToList() : other.DynamicRecipients,
            CarbonCopyRecipients = deepClone ? other.CarbonCopyRecipients?.ToList() : other.CarbonCopyRecipients,
            BlindCarbonCopyRecipients = deepClone ? other.BlindCarbonCopyRecipients?.ToList() : other.BlindCarbonCopyRecipients,
            Subject = other.Subject,
            Content = other.Content,
            PdfContent = other.PdfContent,
            PdfFilename = other.PdfFilename,
            FromName = other.FromName,
            ReplyTo = other.ReplyTo,
            PdfHeaderLogoResourceId = other.PdfHeaderLogoResourceId,
            Configuration = deepClone ? other.Configuration?.ToTriggerConfiguration() : other.Configuration
        };
        
        /// <summary>
        /// Selects the type Trigger from a IQueryable<Trigger>
        /// </summary>
        public static IQueryable<Trigger> SelectAsTrigger(this IQueryable<Trigger> query) => query.Select(other => new Trigger() { 
            Type = other.Type,
            Name = other.Name,
            StaticRecipients = other.StaticRecipients,
            DynamicRecipients = other.DynamicRecipients,
            CarbonCopyRecipients = other.CarbonCopyRecipients,
            BlindCarbonCopyRecipients = other.BlindCarbonCopyRecipients,
            Subject = other.Subject,
            Content = other.Content,
            PdfContent = other.PdfContent,
            PdfFilename = other.PdfFilename,
            FromName = other.FromName,
            ReplyTo = other.ReplyTo,
            PdfHeaderLogoResourceId = other.PdfHeaderLogoResourceId,
            Configuration = other.Configuration
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithTriggerConfiguration(this TriggerConfiguration item, TriggerConfiguration other, bool deepClone = true) {
            item.Attachments = deepClone ? other.Attachments?.ToList() : other.Attachments;
            item.AttachImages = other.AttachImages;
            item.EmbedImages = other.EmbedImages;
            item.AttachPdf = other.AttachPdf;
            item.SimpleMode = other.SimpleMode;
            item.UseHeaderAndFooter = other.UseHeaderAndFooter;
            item.HideNoValues = other.HideNoValues;
            item.HorizontalOrientation = other.HorizontalOrientation;
            item.DistributedGeneration = other.DistributedGeneration;
            item.LegacyGeneration = other.LegacyGeneration;
        }
        
        /// <summary>
        /// Returns a new object of TriggerConfiguration with fileds filled from TriggerConfiguration. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static TriggerConfiguration ToTriggerConfiguration(this TriggerConfiguration other, bool deepClone = true) => new TriggerConfiguration() { 
            Attachments = deepClone ? other.Attachments?.ToList() : other.Attachments,
            AttachImages = other.AttachImages,
            EmbedImages = other.EmbedImages,
            AttachPdf = other.AttachPdf,
            SimpleMode = other.SimpleMode,
            UseHeaderAndFooter = other.UseHeaderAndFooter,
            HideNoValues = other.HideNoValues,
            HorizontalOrientation = other.HorizontalOrientation,
            DistributedGeneration = other.DistributedGeneration,
            LegacyGeneration = other.LegacyGeneration
        };
        
        /// <summary>
        /// Selects the type TriggerConfiguration from a IQueryable<TriggerConfiguration>
        /// </summary>
        public static IQueryable<TriggerConfiguration> SelectAsTriggerConfiguration(this IQueryable<TriggerConfiguration> query) => query.Select(other => new TriggerConfiguration() { 
            Attachments = other.Attachments,
            AttachImages = other.AttachImages,
            EmbedImages = other.EmbedImages,
            AttachPdf = other.AttachPdf,
            SimpleMode = other.SimpleMode,
            UseHeaderAndFooter = other.UseHeaderAndFooter,
            HideNoValues = other.HideNoValues,
            HorizontalOrientation = other.HorizontalOrientation,
            DistributedGeneration = other.DistributedGeneration,
            LegacyGeneration = other.LegacyGeneration
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFolderDto(this FolderDto item, FolderDto other, bool deepClone = true) {
            item.Id = other.Id;
            item.Forms = deepClone ? other.Forms?.Select(value=>value?.ToFormDto())?.ToList() : other.Forms;
            item.Meta = deepClone ? other.Meta?.ToFolderMetadataDto() : other.Meta;
            item.Status = other.Status == null ? null : (FolderDto.StatusValue)other.Status;
        }
        
        /// <summary>
        /// Returns a new object of FolderDto with fileds filled from FolderDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FolderDto ToFolderDto(this FolderDto other, bool deepClone = true) => new FolderDto() { 
            Id = other.Id,
            Forms = deepClone ? other.Forms?.Select(value=>value?.ToFormDto())?.ToList() : other.Forms,
            Meta = deepClone ? other.Meta?.ToFolderMetadataDto() : other.Meta,
            Status = other.Status == null ? null : (FolderDto.StatusValue)other.Status
        };
        
        /// <summary>
        /// Selects the type FolderDto from a IQueryable<FolderDto>
        /// </summary>
        public static IQueryable<FolderDto> SelectAsFolderDto(this IQueryable<FolderDto> query) => query.Select(other => new FolderDto() { 
            Id = other.Id,
            Forms = other.Forms,
            Meta = other.Meta,
            Status = other.Status == null ? null : (FolderDto.StatusValue)other.Status
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFolderMetadataDto(this FolderMetadataDto item, FolderMetadataDto other, bool deepClone = true) {
            item.Name = other.Name;
            item.Description = other.Description;
            item.Icon = other.Icon;
            item.Image = other.Image;
            item.ApplicationId = other.ApplicationId;
        }
        
        /// <summary>
        /// Returns a new object of FolderMetadataDto with fileds filled from FolderMetadataDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FolderMetadataDto ToFolderMetadataDto(this FolderMetadataDto other, bool deepClone = true) => new FolderMetadataDto() { 
            Name = other.Name,
            Description = other.Description,
            Icon = other.Icon,
            Image = other.Image,
            ApplicationId = other.ApplicationId
        };
        
        /// <summary>
        /// Selects the type FolderMetadataDto from a IQueryable<FolderMetadataDto>
        /// </summary>
        public static IQueryable<FolderMetadataDto> SelectAsFolderMetadataDto(this IQueryable<FolderMetadataDto> query) => query.Select(other => new FolderMetadataDto() { 
            Name = other.Name,
            Description = other.Description,
            Icon = other.Icon,
            Image = other.Image,
            ApplicationId = other.ApplicationId
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFormVersionCopyDto(this FormVersionCopyDto item, FormVersionCopyDto other, bool deepClone = true) {
            item.CustomerId = other.CustomerId;
            item.FolderId = other.FolderId;
            item.FormName = other.FormName;
        }
        
        /// <summary>
        /// Returns a new object of FormVersionCopyDto with fileds filled from FormVersionCopyDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FormVersionCopyDto ToFormVersionCopyDto(this FormVersionCopyDto other, bool deepClone = true) => new FormVersionCopyDto() { 
            CustomerId = other.CustomerId,
            FolderId = other.FolderId,
            FormName = other.FormName
        };
        
        /// <summary>
        /// Selects the type FormVersionCopyDto from a IQueryable<FormVersionCopyDto>
        /// </summary>
        public static IQueryable<FormVersionCopyDto> SelectAsFormVersionCopyDto(this IQueryable<FormVersionCopyDto> query) => query.Select(other => new FormVersionCopyDto() { 
            CustomerId = other.CustomerId,
            FolderId = other.FolderId,
            FormName = other.FormName
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithFormVersionCopyResponseDto(this FormVersionCopyResponseDto item, FormVersionCopyResponseDto other, bool deepClone = true) {
            item.Folder = deepClone ? other.Folder?.ToFolderDto() : other.Folder;
            item.Form = deepClone ? other.Form?.ToFormDto() : other.Form;
            item.FormVersion = deepClone ? other.FormVersion?.ToFormVersionDto() : other.FormVersion;
        }
        
        /// <summary>
        /// Returns a new object of FormVersionCopyResponseDto with fileds filled from FormVersionCopyResponseDto. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static FormVersionCopyResponseDto ToFormVersionCopyResponseDto(this FormVersionCopyResponseDto other, bool deepClone = true) => new FormVersionCopyResponseDto() { 
            Folder = deepClone ? other.Folder?.ToFolderDto() : other.Folder,
            Form = deepClone ? other.Form?.ToFormDto() : other.Form,
            FormVersion = deepClone ? other.FormVersion?.ToFormVersionDto() : other.FormVersion
        };
        
        /// <summary>
        /// Selects the type FormVersionCopyResponseDto from a IQueryable<FormVersionCopyResponseDto>
        /// </summary>
        public static IQueryable<FormVersionCopyResponseDto> SelectAsFormVersionCopyResponseDto(this IQueryable<FormVersionCopyResponseDto> query) => query.Select(other => new FormVersionCopyResponseDto() { 
            Folder = other.Folder,
            Form = other.Form,
            FormVersion = other.FormVersion
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithLookupOption(this LookupOption item, LookupOption other, bool deepClone = true) {
            item.Id = other.Id;
            item.Name = other.Name;
        }
        
        /// <summary>
        /// Returns a new object of LookupOption with fileds filled from LookupOption. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static LookupOption ToLookupOption(this LookupOption other, bool deepClone = true) => new LookupOption() { 
            Id = other.Id,
            Name = other.Name
        };
        
        /// <summary>
        /// Selects the type LookupOption from a IQueryable<LookupOption>
        /// </summary>
        public static IQueryable<LookupOption> SelectAsLookupOption(this IQueryable<LookupOption> query) => query.Select(other => new LookupOption() { 
            Id = other.Id,
            Name = other.Name
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSearchDataSource(this SearchDataSource item, SearchDataSource other, bool deepClone = true) {
            item.Id = other.Id;
            item.Mapping = deepClone ? other.Mapping?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Mapping;
        }
        
        /// <summary>
        /// Returns a new object of SearchDataSource with fileds filled from SearchDataSource. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static SearchDataSource ToSearchDataSource(this SearchDataSource other, bool deepClone = true) => new SearchDataSource() { 
            Id = other.Id,
            Mapping = deepClone ? other.Mapping?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Mapping
        };
        
        /// <summary>
        /// Selects the type SearchDataSource from a IQueryable<SearchDataSource>
        /// </summary>
        public static IQueryable<SearchDataSource> SelectAsSearchDataSource(this IQueryable<SearchDataSource> query) => query.Select(other => new SearchDataSource() { 
            Id = other.Id,
            Mapping = other.Mapping
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSubForm(this SubForm item, SubForm other, bool deepClone = true) {
            item.Uid = other.Uid;
            item.Fields = deepClone ? other.Fields?.Select(value=>value?.ToField())?.ToList() : other.Fields;
            item.Rules = deepClone ? other.Rules?.Select(value=>value?.ToRule())?.ToList() : other.Rules;
            item.Triggers = deepClone ? other.Triggers?.Select(value=>value?.ToTrigger())?.ToList() : other.Triggers;
            item.Settings = deepClone ? other.Settings?.ToSettings() : other.Settings;
        }
        
        /// <summary>
        /// Returns a new object of SubForm with fileds filled from SubForm. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static SubForm ToSubForm(this SubForm other, bool deepClone = true) => new SubForm() { 
            Uid = other.Uid,
            Fields = deepClone ? other.Fields?.Select(value=>value?.ToField())?.ToList() : other.Fields,
            Rules = deepClone ? other.Rules?.Select(value=>value?.ToRule())?.ToList() : other.Rules,
            Triggers = deepClone ? other.Triggers?.Select(value=>value?.ToTrigger())?.ToList() : other.Triggers,
            Settings = deepClone ? other.Settings?.ToSettings() : other.Settings
        };
        
        /// <summary>
        /// Selects the type SubForm from a IQueryable<SubForm>
        /// </summary>
        public static IQueryable<SubForm> SelectAsSubForm(this IQueryable<SubForm> query) => query.Select(other => new SubForm() { 
            Uid = other.Uid,
            Fields = other.Fields,
            Rules = other.Rules,
            Triggers = other.Triggers,
            Settings = other.Settings
        });
    }
}
