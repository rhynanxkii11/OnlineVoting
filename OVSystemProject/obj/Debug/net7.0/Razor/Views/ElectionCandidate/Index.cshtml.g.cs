#pragma checksum "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0833a77fb7da4edc2852134f7a0c55c314cca391"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ElectionCandidate_Index), @"mvc.1.0.view", @"/Views/ElectionCandidate/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0833a77fb7da4edc2852134f7a0c55c314cca391", @"/Views/ElectionCandidate/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b904f699bfbd6392a1a1f90182d80aba242d165", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("Identifier", "/Views/ElectionCandidate/Index.cshtml")]
    [global::System.Runtime.CompilerServices.CreateNewOnMetadataUpdateAttribute]
    #nullable restore
    public class Views_ElectionCandidate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Positions>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("candidatePhoto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
  
    ViewData["Title"] = "Candidates";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""d-flex justify-content-center w-100 bg-success"" style=""margin-bottom"">
        <h1 style=""font-size: 60px; font-weight: 600;"" class=""text-white"">
            ELECTION CANDIDATE
        </h1>
    </div>
    <div class=""d-flex justify-content-center w-100 pt-5"">
        <div class=""row g-3 gap-sm-4"">
");
#nullable restore
#line 15 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
             if (Model != null && Model.Any())
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
                 foreach (var position in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"d-flex justify-content-center text-uppercase\">\r\n                        <h1 class=\"text-success\">");
#nullable restore
#line (20,51)-(20,72) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
Write(position.PositionName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    </div>\r\n");
#nullable restore
#line 23 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
                     foreach (var candidate in position.Candidates)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"card\" style=\"width: 18rem;\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0833a77fb7da4edc2852134f7a0c55c314cca3916441", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1010, "~/img/candidate/", 1010, 16, true);
#nullable restore
#line (26,55)-(26,71) 32 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
AddHtmlAttributeValue("", 1026, candidate.Photo, 1026, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <div class=\"card-body\">\r\n                                <h5 class=\"text-uppercase\">Name: ");
#nullable restore
#line (28,67)-(28,85) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
Write(candidate.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5>Age: ");
#nullable restore
#line (29,43)-(29,56) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
Write(candidate.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5>Sex: ");
#nullable restore
#line (30,43)-(30,56) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
Write(candidate.Sex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            </div>\r\n                            <div class=\"card-footer text-center\">\r\n                                <h5>");
#nullable restore
#line (33,38)-(33,53) 6 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
Write(candidate.Party);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 36 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
                 

            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td colspan=\"6\" class=\"text-center\">\r\n                        <div>\r\n                            No candidates available.\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 49 "C:\Users\lares User\source\repos\OVSystemProject\OVSystemProject\Views\ElectionCandidate\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Positions>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
