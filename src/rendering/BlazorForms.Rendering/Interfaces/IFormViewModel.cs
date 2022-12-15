﻿using BlazorForms.FlowRules;
using BlazorForms.Flows.Definitions;
using BlazorForms.Forms;
using BlazorForms.Shared;
using BlazorForms.Shared.Reflection;
using BlazorForms.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForms.Rendering.Interfaces
{
    public interface IFormViewModel<T> : IFormViewModel where T : class, IFlowModel
    {
        T Model { get; }
    }

    public interface IFormViewModel : IRenderingViewModel
    {
        IFlowModel? ModelUntyped { get; }
        IFlowParams? Params { get; }
        IFlowContextNoModel? Context { get; }
        string? RefId { get; }
        FormDetails? FormData { get; }
        FormSettingsViewState FormSettings { get; }
        FlowParamsGeneric? FormParameters { get; }
        IEnumerable<IGrouping<string, FieldControlDetails>>? FieldsGrouped { get; }
        Dictionary<string, List<FieldControlDetails>>? Tables { get; }
        Dictionary<string, List<FieldControlDetails>>? Repeaters { get; }
        IEnumerable<RuleExecutionResult>? Validations { get; set; }
        IJsonPathNavigator? PathNavi { get; }
        bool FormAccessDenied { get; }
        string? FormAssignedUser { get; }
        IEnumerable<FieldControlDetails>? ActionFields { get; }
        FieldControlDetails? SubmitAction { get; }
        string? SubmitActionName { get; }
        FieldControlDetails? RejectAction { get; }
        string? RejectActionName { get; }
        string? SaveActionName { get; }
        string? ExceptionMessage { get; }
        string? ExceptionStackTrace { get; }
        string? ExceptionType { get; }

        // main flow api
        Task InitiateFlow(string flowName, string refId, string pk);
        Task FinishFlow(string refId, string binding = null);
        Task ReloadFormData();
        Task<RuleEngineExecutionResult> TriggerRules(string formName, FieldBinding modelBinding, FormRuleTriggers? trigger = null, int rowIndex = 0);
        //Task<RuleEngineExecutionResult> TriggerFormLoadRulesRules();
        Task SaveForm(string actionBinding = null, string operationName = null);
        Task SubmitForm(string binding = null, string operationName = null);
        Task RejectForm(string binding = null, string operationName = null);
        Task LoadFlowDefaultForm(string refId);
        Task ApplyFormData(FormDetails form, IFlowModel model);

        // useful api
        List<SelectableListItem> GetSelectableListData(FieldControlDetails field);
        FieldControlDetails GetRowField(FieldControlDetails template, int row);
        FieldControlDetails GetFieldByName(string name);
        IEnumerable<RuleExecutionResult> GetDynamicFieldValidations();
        Task<bool> CheckFormUserAccess(FormDetails form, UserViewAccessInformation accessInfo, IFlowModel model, FlowParamsGeneric flowParams);

        // ModelNavi
        object ModelNaviGetValueObject(string modelBinding);
        string ModelNaviGetValue(string modelBinding);
        object ModelNaviGetValue(string tableBinding, int rowIndex, string modelBinding);
        void ModelNaviSetValue(string modelBinding, object val);
        void ModelNaviSetValue(string tableBinding, int rowIndex, string modelBinding, object val);
        IEnumerable<object> ModelNaviGetItems(string itemsBinding);
        void ClearRowFields();

        // FastReflection
        object FieldGetValue(object model, FieldBinding binding);
        object FieldGetNameValue(object model, FieldBinding binding);
        object FieldGetIdValue(object model, FieldBinding binding);
        IEnumerable<object> FieldGetItemsValue(object model, FieldBinding binding);
        IEnumerable<object> FieldGetTableValue(object model, FieldBinding binding);
        object FieldGetRowValue(object model, FieldBinding binding, int rowIndex);
        void FieldSetValue(object model, FieldBinding binding, object value);
    }
}