#pragma checksum "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "512f3a587bef10a591823ec8a31ffcd80d8b7af7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_Index), @"mvc.1.0.view", @"/Views/Manage/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Univer\NTR\TimeReporter\Views\_ViewImports.cshtml"
using TimeReporter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Univer\NTR\TimeReporter\Views\_ViewImports.cshtml"
using TimeReporter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"512f3a587bef10a591823ec8a31ffcd80d8b7af7", @"/Views/Manage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"547daf1e3fb964da621fd107c6c3ee8f3a5d1878", @"/Views/_ViewImports.cshtml")]
    public class Views_Manage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManageOption>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
  
    ViewBag.Title = "Manage panel";
    ViewData["Title"] = "Manage panel";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
 if (TempData["Alert"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">\r\n        <a href=\"#\" class=\"close\" data-dismiss=\"alert\">×</a>\r\n        ");
#nullable restore
#line 12 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
   Write(TempData["Alert"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 14 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 16 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">\r\n        <a href=\"#\" class=\"close\" data-dismiss=\"alert\">×</a>\r\n        ");
#nullable restore
#line 20 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
   Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 22 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>\r\n    Manage Your Projects\r\n</h2>\r\n\r\n<fieldset style=\"padding:20px; border:3px solid #4238ca; background:#f6f8ff; width: 500px; margin-top: 10px\">\r\n    <legend>Select Your Project (Or Create One)</legend>\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 31 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
         using (Html.BeginForm("SelectSurname", "Manage", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col\">\r\n                ");
#nullable restore
#line 34 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
           Write(Html.DropDownListFor(model => model.SelectedSurname,
                    new SelectList(Model.Surnames),
                    new { @class="selectpicker", onchange = "this.form.submit();"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <input type=\"hidden\" name=\"selectedMonth\"");
            BeginWriteAttribute("value", " value=", 1140, "", 1167, 1);
#nullable restore
#line 37 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 1147, Model.SelectedMonth, 1147, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedYear\"");
            BeginWriteAttribute("value", " value=", 1228, "", 1254, 1);
#nullable restore
#line 38 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 1235, Model.SelectedYear, 1235, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n");
#nullable restore
#line 40 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"row\" style=\"margin-top: 10px\">\r\n");
#nullable restore
#line 44 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
         using (Html.BeginForm("SelectProject", "Manage", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col\">\r\n                <select name=\"selectedProject\" class=\"selectpicker\" onchange=\"this.form.submit();\">\r\n");
#nullable restore
#line 48 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                     if (Model.Projects.Count > 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                         foreach (var project in Model.Projects)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                             if (ViewBag.isActive)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                 if (project == Model.SelectedProject)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "512f3a587bef10a591823ec8a31ffcd80d8b7af78438", async() => {
#nullable restore
#line 56 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                                               Write(project);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (active)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                      WriteLiteral(project);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 57 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "512f3a587bef10a591823ec8a31ffcd80d8b7af710871", async() => {
#nullable restore
#line 60 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                                      Write(project);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                      WriteLiteral(project);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 61 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                 
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                 if (project == Model.SelectedProject)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "512f3a587bef10a591823ec8a31ffcd80d8b7af713408", async() => {
#nullable restore
#line 67 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                                               Write(project);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (closed)");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                      WriteLiteral(project);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 68 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "512f3a587bef10a591823ec8a31ffcd80d8b7af715842", async() => {
#nullable restore
#line 71 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                                      Write(project);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                      WriteLiteral(project);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 72 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                         
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "512f3a587bef10a591823ec8a31ffcd80d8b7af718452", async() => {
                WriteLiteral("You don\'t have projects, create one");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </select>\r\n");
            WriteLiteral("                <input type=\"hidden\" name=\"selectedSurname\"");
            BeginWriteAttribute("value", " value=", 3339, "", 3368, 1);
#nullable restore
#line 84 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 3346, Model.SelectedSurname, 3346, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n            </div>\r\n");
#nullable restore
#line 87 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"row\" style=\"margin-top: 10px\">\r\n");
#nullable restore
#line 91 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
         using (Html.BeginForm("SelectMonth", "Manage", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col\">\r\n                ");
#nullable restore
#line 94 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
           Write(Html.DropDownListFor(model => model.SelectedMonth,
                    Enumerable.Range(1, 12).Select(i =>
                        new SelectListItem
                        {
                            Value = i.ToString(),
                            Text = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(i)
                        }),
                    new { @class="selectpicker", data_width="150px", onchange = "this.form.submit();"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <input type=\"hidden\" name=\"selectedSurname\"");
            BeginWriteAttribute("value", " value=", 4143, "", 4172, 1);
#nullable restore
#line 102 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 4150, Model.SelectedSurname, 4150, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedProject\"");
            BeginWriteAttribute("value", " value=", 4236, "", 4265, 1);
#nullable restore
#line 103 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 4243, Model.SelectedProject, 4243, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedYear\"");
            BeginWriteAttribute("value", " value=", 4326, "", 4352, 1);
#nullable restore
#line 104 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 4333, Model.SelectedYear, 4333, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n");
#nullable restore
#line 106 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 108 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
         using (Html.BeginForm("SelectYear", "Manage", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col\" style=\"margin-right: 10px\">\r\n                ");
#nullable restore
#line 111 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
           Write(Html.DropDownListFor(model => model.SelectedYear,
                    Enumerable.Range(2015, 11).Select(i =>
                        new SelectListItem
                        {
                            Value = i.ToString(), 
                            Text = i.ToString()
                        }),
                    new { @class="selectpicker", data_width="fit", onchange = "this.form.submit();"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <input type=\"hidden\" name=\"selectedSurname\"");
            BeginWriteAttribute("value", " value=", 5024, "", 5053, 1);
#nullable restore
#line 119 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 5031, Model.SelectedSurname, 5031, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedProject\"");
            BeginWriteAttribute("value", " value=", 5117, "", 5146, 1);
#nullable restore
#line 120 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 5124, Model.SelectedProject, 5124, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedMonth\"");
            BeginWriteAttribute("value", " value=", 5208, "", 5235, 1);
#nullable restore
#line 121 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 5215, Model.SelectedMonth, 5215, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n");
#nullable restore
#line 123 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 124 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
         using (Html.BeginForm("CloseProject", "Manage", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col\">\r\n                <input type=\"hidden\" name=\"selectedSurname\"");
            BeginWriteAttribute("value", " value=", 5448, "", 5477, 1);
#nullable restore
#line 127 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 5455, Model.SelectedSurname, 5455, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedMonth\"");
            BeginWriteAttribute("value", " value=", 5539, "", 5566, 1);
#nullable restore
#line 128 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 5546, Model.SelectedMonth, 5546, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedYear\"");
            BeginWriteAttribute("value", " value=", 5627, "", 5653, 1);
#nullable restore
#line 129 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 5634, Model.SelectedYear, 5634, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"selectedProject\"");
            BeginWriteAttribute("value", " value=", 5717, "", 5746, 1);
#nullable restore
#line 130 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 5724, Model.SelectedProject, 5724, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <button type=\"submit\" class=\"btn btn-secondary\">Close This Project</button>\r\n            </div>\r\n");
#nullable restore
#line 133 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</fieldset>\r\n\r\n<div style=\"margin-top: 10px\">\r\n    <button");
            BeginWriteAttribute("href", " href=\"", 5945, "\"", 5952, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#CreateProjectModal\"\r\n            data-url=\'");
#nullable restore
#line 139 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                  Write(Url.Action("CreateProjectModal", new {selectedSurname = Model.SelectedSurname, 
                          selectedMonth = Model.SelectedMonth, selectedYear = Model.SelectedYear,
                      selectedProject = Model.SelectedProject}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\'>\r\n        Create New Project\r\n    </button>\r\n</div>\r\n\r\n");
#nullable restore
#line 146 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
 if (ViewBag.budget != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>\r\n        Current project budget: ");
#nullable restore
#line 149 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                           Write(ViewBag.budget);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </h4>\r\n");
#nullable restore
#line 151 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 153 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
 if (Model.SubmittedTime.Count > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
     for (int i = 0; i < Model.ProjectWorkers.Count; ++i)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <fieldset style=""padding:30px; border:3px solid #4238ca; background:#f6f8ff;"">
            <legend>Report</legend>
            <table class=""table table-bordered table-hover"">
                <tr>
                    <th scope=""row"">
                        Worker
                    </th>
                    <td>
                        ");
#nullable restore
#line 166 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                   Write(Model.ProjectWorkers[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">\r\n                        Submitted Time\r\n                    </th>\r\n                    <td>\r\n                        ");
#nullable restore
#line 174 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                   Write(Model.SubmittedTime[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">\r\n                        Is Month Submitted\r\n                    </th>\r\n                    <td>\r\n");
#nullable restore
#line 182 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                         if (@Model.IsFrozen[i])
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"display-field\">\r\n                                Yes\r\n                            </div>\r\n");
#nullable restore
#line 187 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"display-field\">\r\n                                No\r\n                            </div>\r\n");
#nullable restore
#line 193 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <th scope=\"row\">\r\n                        Accepted Time\r\n                    </th>\r\n                    <td>\r\n                        ");
#nullable restore
#line 201 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
                   Write(Model.AcceptedTime[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n\r\n            </table>\r\n");
#nullable restore
#line 206 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
             using (Html.BeginForm("AcceptTime", "Manage", FormMethod.Post))
            {

                

#line default
#line hidden
#nullable disable
#nullable restore
#line 209 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
           Write(Html.TextBox("time", @Model.AcceptedTime[i], new {onchange = "show(this);", type = "number"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <input type=\"hidden\" name=\"selectedSurname\"");
            BeginWriteAttribute("value", " value=", 8478, "", 8507, 1);
#nullable restore
#line 211 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 8485, Model.SelectedSurname, 8485, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"selectedMonth\"");
            BeginWriteAttribute("value", " value=", 8573, "", 8600, 1);
#nullable restore
#line 212 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 8580, Model.SelectedMonth, 8580, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"selectedYear\"");
            BeginWriteAttribute("value", " value=", 8665, "", 8691, 1);
#nullable restore
#line 213 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 8672, Model.SelectedYear, 8672, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"selectedProject\"");
            BeginWriteAttribute("value", " value=", 8759, "", 8788, 1);
#nullable restore
#line 214 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 8766, Model.SelectedProject, 8766, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"worker\"");
            BeginWriteAttribute("value", " value=", 8847, "", 8878, 1);
#nullable restore
#line 215 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 8854, Model.ProjectWorkers[i], 8854, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"isMonthSubmitted\"");
            BeginWriteAttribute("value", " value=", 8947, "", 8983, 1);
#nullable restore
#line 216 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 8954, Model.IsFrozen[i].ToString(), 8954, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"idx\"");
            BeginWriteAttribute("value", " value=", 9039, "", 9048, 1);
#nullable restore
#line 217 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
WriteAttributeValue("", 9046, i, 9046, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <button type=\"submit\" class=\"btn btn-outline-primary\">Edit Accepted Time</button>\r\n");
#nullable restore
#line 219 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </fieldset>\r\n");
#nullable restore
#line 221 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 221 "D:\Univer\NTR\TimeReporter\Views\Manage\Index.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!-- Modal -->\r\n<div class=\"modal\" id=\"CreateProjectModal\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"exampleModalLabel\"\r\n     aria-hidden=\"true\">\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManageOption> Html { get; private set; }
    }
}
#pragma warning restore 1591
