#pragma checksum "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e0eda1406d18ee5801d497fb067d229f89ca7be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transactions_DislayRangeTrans), @"mvc.1.0.view", @"/Views/Transactions/DislayRangeTrans.cshtml")]
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
#line 1 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\_ViewImports.cshtml"
using EktivaBankNetApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\_ViewImports.cshtml"
using EktivaBankNetApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e0eda1406d18ee5801d497fb067d229f89ca7be", @"/Views/Transactions/DislayRangeTrans.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b466985837ddd543976be1fc068dc1cda9ddab27", @"/Views/_ViewImports.cshtml")]
    public class Views_Transactions_DislayRangeTrans : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EktivaBankNetApp.Models.ViewModel.Transaction>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:darkgreen"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Accounts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
  
    ViewData["Title"] = "DislayRangeTrans";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e0eda1406d18ee5801d497fb067d229f89ca7be4466", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<h5 style=""font-weight: bold; color:crimson""> Display Range Transactions</h5>
<hr style=""margin-top:-10px; border-color:black"" />
<table style=""border: 2px solid black;"" class=""table"">
    <thead style=""border: 2px solid black;"">
        <tr style=""border: 2px solid black;"">
            <th style=""border: 2px solid black;"">
                ");
#nullable restore
#line 15 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
           Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("            \r\n            <th style=\"border: 2px solid black;\">\r\n                ");
#nullable restore
#line 22 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th style=\"border: 2px solid black;\">\r\n                ");
#nullable restore
#line 25 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
           Write(Html.DisplayNameFor(model => model.BalBefore));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th style=\"border: 2px solid black;\">\r\n                ");
#nullable restore
#line 28 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
           Write(Html.DisplayNameFor(model => model.BalAfter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th style=\"border: 2px solid black;\">\r\n                ");
#nullable restore
#line 32 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
           Write(Html.DisplayNameFor(model => model.transactionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody style=\"border: 1px dashed black;\">\r\n");
#nullable restore
#line 37 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr style=\"border: 1px dashed black;\">\r\n                 <td style=\"border: 1px dashed black;\">\r\n                    ");
#nullable restore
#line 41 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
               Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("                <td style=\"border: 1px dashed black;\">\r\n                    ");
#nullable restore
#line 47 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"border: 1px dashed black;\">\r\n                    ");
#nullable restore
#line 50 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
               Write(Html.DisplayFor(modelItem => item.BalBefore));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"border: 1px dashed black;\">\r\n                    ");
#nullable restore
#line 53 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
               Write(Html.DisplayFor(modelItem => item.BalAfter));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n               \r\n                <td style=\"border: 1px dashed black;\">\r\n                    ");
#nullable restore
#line 57 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
               Write(Html.DisplayFor(modelItem => item.transactionDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 60 "C:\Users\ektiv\Desktop\Revature\MyProjects\EktivaBankNetApp\Views\Transactions\DislayRangeTrans.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EktivaBankNetApp.Models.ViewModel.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591