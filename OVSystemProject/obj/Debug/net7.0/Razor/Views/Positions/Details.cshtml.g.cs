#pragma checksum "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba748ce6d9ea98f611ddec2e9464c23e817406a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Positions_Details), @"mvc.1.0.view", @"/Views/Positions/Details.cshtml")]
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
#line 1 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\_ViewImports.cshtml"
using OVSystemProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\_ViewImports.cshtml"
using OVSystemProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\_ViewImports.cshtml"
using OVSystemProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba748ce6d9ea98f611ddec2e9464c23e817406a3", @"/Views/Positions/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b904f699bfbd6392a1a1f90182d80aba242d165", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("Identifier", "/Views/Positions/Details.cshtml")]
    [global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdateAttribute]
    #nullable restore
    public class Views_Positions_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Positions>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 50px; height: 50px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
  
    ViewData["Title"] = "List of Candidates";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container bg-white p-4\" style=\"box-shadow: 0 4px 8px rgba(0,0,0,0.3);\">\r\n    <div class=\"pt-4 pb-3\">\r\n        <h3>");
#nullable restore
#line (8,14)-(8,31) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
    </div>
    <table class=""table table-striped p-3"" id=""example"">
        <thead>
            <tr class=""bg-secondary"">
                <th>CandidateId</th>
                <th>Photo</th>
                <th>Position Id</th>
                <th>Full Name</th>
                <th>Age</th>
                <th>Sex</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 22 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
                 foreach (var candidate in Model.Candidates)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line (25,30)-(25,51) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
Write(candidate.CandidateId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ba748ce6d9ea98f611ddec2e9464c23e817406a35730", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 893, "~/img/candidate/", 893, 16, true);
#nullable restore
#line (28,55)-(28,71) 31 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
AddHtmlAttributeValue("", 909, candidate.Photo, 909, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                        <td>");
#nullable restore
#line (30,30)-(30,50) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
Write(candidate.PositionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line (31,30)-(31,48) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
Write(candidate.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line (32,30)-(32,43) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
Write(candidate.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line (33,30)-(33,43) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
Write(candidate.Sex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 35 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\Positions\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("           \r\n\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Positions> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
