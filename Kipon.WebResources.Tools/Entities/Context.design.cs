//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute()]

namespace Kipon.Dynamics.Plugin.Entities
{
	
	
	/// <summary>
	/// A solution which contains CRM customizations.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("solution")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9154")]
	public partial class Solution : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public Solution() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "solution";
		
		public const int EntityTypeCode = 7100;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		private void OnPropertyChanged(string propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void OnPropertyChanging(string propertyName)
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
			}
		}
		
		/// <summary>
		/// A link to an optional configuration page for this solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("configurationpageid")]
		public Microsoft.Xrm.Sdk.EntityReference ConfigurationPageId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("configurationpageid");
			}
			set
			{
				this.OnPropertyChanging("ConfigurationPageId");
				this.SetAttributeValue("configurationpageid", value);
				this.OnPropertyChanged("ConfigurationPageId");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who created the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}
		
		/// <summary>
		/// Date and time when the solution was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who created the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
		}
		
		/// <summary>
		/// Description of the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
		public string Description
		{
			get
			{
				return this.GetAttributeValue<string>("description");
			}
			set
			{
				this.OnPropertyChanging("Description");
				this.SetAttributeValue("description", value);
				this.OnPropertyChanged("Description");
			}
		}
		
		/// <summary>
		/// User display name for the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("friendlyname")]
		public string FriendlyName
		{
			get
			{
				return this.GetAttributeValue<string>("friendlyname");
			}
			set
			{
				this.OnPropertyChanging("FriendlyName");
				this.SetAttributeValue("friendlyname", value);
				this.OnPropertyChanged("FriendlyName");
			}
		}
		
		/// <summary>
		/// Date and time when the solution was installed/upgraded.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("installedon")]
		public System.Nullable<System.DateTime> InstalledOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("installedon");
			}
		}
		
		/// <summary>
		/// Indicates whether the solution is managed or unmanaged.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismanaged")]
		public System.Nullable<bool> IsManaged
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("ismanaged");
			}
		}
		
		/// <summary>
		/// Indicates whether the solution is visible outside of the platform.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isvisible")]
		public System.Nullable<bool> IsVisible
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("isvisible");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who last modified the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}
		
		/// <summary>
		/// Date and time when the solution was last modified.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who modified the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
		}
		
		/// <summary>
		/// Unique identifier of the organization associated with the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
		public Microsoft.Xrm.Sdk.EntityReference OrganizationId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
			}
		}
		
		/// <summary>
		/// Unique identifier of the parent solution. Should only be non-null if this solution is a patch.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentsolutionid")]
		public Microsoft.Xrm.Sdk.EntityReference ParentSolutionId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentsolutionid");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointassetid")]
		public string PinpointAssetId
		{
			get
			{
				return this.GetAttributeValue<string>("pinpointassetid");
			}
		}
		
		/// <summary>
		/// Identifier of the publisher of this solution in Microsoft Pinpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointpublisherid")]
		public System.Nullable<long> PinpointPublisherId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("pinpointpublisherid");
			}
		}
		
		/// <summary>
		/// Default locale of the solution in Microsoft Pinpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointsolutiondefaultlocale")]
		public string PinpointSolutionDefaultLocale
		{
			get
			{
				return this.GetAttributeValue<string>("pinpointsolutiondefaultlocale");
			}
		}
		
		/// <summary>
		/// Identifier of the solution in Microsoft Pinpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointsolutionid")]
		public System.Nullable<long> PinpointSolutionId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("pinpointsolutionid");
			}
		}
		
		/// <summary>
		/// Unique identifier of the publisher.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("publisherid")]
		public Microsoft.Xrm.Sdk.EntityReference PublisherId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("publisherid");
			}
			set
			{
				this.OnPropertyChanging("PublisherId");
				this.SetAttributeValue("publisherid", value);
				this.OnPropertyChanged("PublisherId");
			}
		}
		
		/// <summary>
		/// Unique identifier of the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
		public System.Nullable<System.Guid> SolutionId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("solutionid");
			}
			set
			{
				this.OnPropertyChanging("SolutionId");
				this.SetAttributeValue("solutionid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("SolutionId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				this.SolutionId = value;
			}
		}
		
		/// <summary>
		/// Solution package source organization version
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionpackageversion")]
		public string SolutionPackageVersion
		{
			get
			{
				return this.GetAttributeValue<string>("solutionpackageversion");
			}
			set
			{
				this.OnPropertyChanging("SolutionPackageVersion");
				this.SetAttributeValue("solutionpackageversion", value);
				this.OnPropertyChanged("SolutionPackageVersion");
			}
		}
		
		/// <summary>
		/// Solution Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutiontype")]
		public Microsoft.Xrm.Sdk.OptionSetValue SolutionType
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("solutiontype");
			}
			set
			{
				this.OnPropertyChanging("SolutionType");
				this.SetAttributeValue("solutiontype", value);
				this.OnPropertyChanged("SolutionType");
			}
		}
		
		/// <summary>
		/// The unique name of this solution
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("uniquename")]
		public string UniqueName
		{
			get
			{
				return this.GetAttributeValue<string>("uniquename");
			}
			set
			{
				this.OnPropertyChanging("UniqueName");
				this.SetAttributeValue("uniquename", value);
				this.OnPropertyChanged("UniqueName");
			}
		}
		
		/// <summary>
		/// Solution version, used to identify a solution for upgrades and hotfixes.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("version")]
		public string Version
		{
			get
			{
				return this.GetAttributeValue<string>("version");
			}
			set
			{
				this.OnPropertyChanging("Version");
				this.SetAttributeValue("version", value);
				this.OnPropertyChanged("Version");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
		
		/// <summary>
		/// 1:N solution_parent_solution
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referenced)]
		public System.Collections.Generic.IEnumerable<Kipon.Dynamics.Plugin.Entities.Solution> Referencedsolution_parent_solution
		{
			get
			{
				return this.GetRelatedEntities<Kipon.Dynamics.Plugin.Entities.Solution>("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referenced);
			}
			set
			{
				this.OnPropertyChanging("Referencedsolution_parent_solution");
				this.SetRelatedEntities<Kipon.Dynamics.Plugin.Entities.Solution>("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referenced, value);
				this.OnPropertyChanged("Referencedsolution_parent_solution");
			}
		}
		
		/// <summary>
		/// 1:N solution_solutioncomponent
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solution_solutioncomponent")]
		public System.Collections.Generic.IEnumerable<Kipon.Dynamics.Plugin.Entities.SolutionComponent> solution_solutioncomponent
		{
			get
			{
				return this.GetRelatedEntities<Kipon.Dynamics.Plugin.Entities.SolutionComponent>("solution_solutioncomponent", null);
			}
			set
			{
				this.OnPropertyChanging("solution_solutioncomponent");
				this.SetRelatedEntities<Kipon.Dynamics.Plugin.Entities.SolutionComponent>("solution_solutioncomponent", null, value);
				this.OnPropertyChanged("solution_solutioncomponent");
			}
		}
		
		/// <summary>
		/// N:1 solution_parent_solution
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentsolutionid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referencing)]
		public Kipon.Dynamics.Plugin.Entities.Solution Referencingsolution_parent_solution
		{
			get
			{
				return this.GetRelatedEntity<Kipon.Dynamics.Plugin.Entities.Solution>("solution_parent_solution", Microsoft.Xrm.Sdk.EntityRole.Referencing);
			}
		}
	}
	
	/// <summary>
	/// A component of a CRM solution.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("solutioncomponent")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9154")]
	public partial class SolutionComponent : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public SolutionComponent() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "solutioncomponent";
		
		public const int EntityTypeCode = 7103;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		private void OnPropertyChanged(string propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void OnPropertyChanging(string propertyName)
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
			}
		}
		
		/// <summary>
		/// The object type code of the component.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componenttype")]
		public Microsoft.Xrm.Sdk.OptionSetValue ComponentType
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("componenttype");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who created the solution
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}
		
		/// <summary>
		/// Date and time when the solution was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who created the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
		}
		
		/// <summary>
		/// Indicates whether this component is metadata or data.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismetadata")]
		public System.Nullable<bool> IsMetadata
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("ismetadata");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who last modified the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}
		
		/// <summary>
		/// Date and time when the solution was last modified.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who modified the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
		}
		
		/// <summary>
		/// Unique identifier of the object with which the component is associated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("objectid")]
		public System.Nullable<System.Guid> ObjectId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("objectid");
			}
		}
		
		/// <summary>
		/// Indicates the include behavior of the root component.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootcomponentbehavior")]
		public Microsoft.Xrm.Sdk.OptionSetValue RootComponentBehavior
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("rootcomponentbehavior");
			}
		}
		
		/// <summary>
		/// The parent ID of the subcomponent, which will be a root
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootsolutioncomponentid")]
		public System.Nullable<System.Guid> RootSolutionComponentId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("rootsolutioncomponentid");
			}
		}
		
		/// <summary>
		/// Unique identifier of the solution component.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutioncomponentid")]
		public System.Nullable<System.Guid> SolutionComponentId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("solutioncomponentid");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutioncomponentid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				base.Id = value;
			}
		}
		
		/// <summary>
		/// Unique identifier of the solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
		public Microsoft.Xrm.Sdk.EntityReference SolutionId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("solutionid");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
		
		/// <summary>
		/// 1:N solutioncomponent_parent_solutioncomponent
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced)]
		public System.Collections.Generic.IEnumerable<Kipon.Dynamics.Plugin.Entities.SolutionComponent> Referencedsolutioncomponent_parent_solutioncomponent
		{
			get
			{
				return this.GetRelatedEntities<Kipon.Dynamics.Plugin.Entities.SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced);
			}
			set
			{
				this.OnPropertyChanging("Referencedsolutioncomponent_parent_solutioncomponent");
				this.SetRelatedEntities<Kipon.Dynamics.Plugin.Entities.SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referenced, value);
				this.OnPropertyChanged("Referencedsolutioncomponent_parent_solutioncomponent");
			}
		}
		
		/// <summary>
		/// N:1 solution_solutioncomponent
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solution_solutioncomponent")]
		public Kipon.Dynamics.Plugin.Entities.Solution solution_solutioncomponent
		{
			get
			{
				return this.GetRelatedEntity<Kipon.Dynamics.Plugin.Entities.Solution>("solution_solutioncomponent", null);
			}
		}
		
		/// <summary>
		/// N:1 solutioncomponent_parent_solutioncomponent
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootsolutioncomponentid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referencing)]
		public Kipon.Dynamics.Plugin.Entities.SolutionComponent Referencingsolutioncomponent_parent_solutioncomponent
		{
			get
			{
				return this.GetRelatedEntity<Kipon.Dynamics.Plugin.Entities.SolutionComponent>("solutioncomponent_parent_solutioncomponent", Microsoft.Xrm.Sdk.EntityRole.Referencing);
			}
		}
	}
	
	/// <summary>
	/// Represents a source of entities bound to a CRM service. It tracks and manages changes made to the retrieved entities.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9154")]
	public partial class ContextService : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
	{
		
		/// <summary>
		/// Constructor.
		/// </summary>
		public ContextService(Microsoft.Xrm.Sdk.IOrganizationService service) : 
				base(service)
		{
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Kipon.Dynamics.Plugin.Entities.Solution"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Kipon.Dynamics.Plugin.Entities.Solution> SolutionSet
		{
			get
			{
				return this.CreateQuery<Kipon.Dynamics.Plugin.Entities.Solution>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Kipon.Dynamics.Plugin.Entities.SolutionComponent"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Kipon.Dynamics.Plugin.Entities.SolutionComponent> SolutionComponentSet
		{
			get
			{
				return this.CreateQuery<Kipon.Dynamics.Plugin.Entities.SolutionComponent>();
			}
		}
	}
}
