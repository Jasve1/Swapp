#pragma checksum "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "110bd57de3ad6f7136ac13527ca48ca5d6b1d43e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductDetailsDisplay), @"mvc.1.0.view", @"/Views/Shared/_ProductDetailsDisplay.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ProductDetailsDisplay.cshtml", typeof(AspNetCore.Views_Shared__ProductDetailsDisplay))]
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
#line 3 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\_ViewImports.cshtml"
using Swapp.Models;

#line default
#line hidden
#line 4 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\_ViewImports.cshtml"
using Swapp.Models.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\_ViewImports.cshtml"
using Swapp.Data;

#line default
#line hidden
#line 6 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"110bd57de3ad6f7136ac13527ca48ca5d6b1d43e", @"/Views/Shared/_ProductDetailsDisplay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a9570812d1bcdb6143e047dbc87b9d13adb8d18", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductDetailsDisplay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/exit.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("exit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("productDropDown"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profilePic"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 8, true);
            WriteLiteral("\r\n\r\n<div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 24, "\"", 45, 1);
#line 4 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
WriteAttributeValue("", 29, Model.ProductId, 29, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(46, 106, true);
            WriteLiteral(" class=\"productDisplay\">\r\n    <div class=\"display\">\r\n        <div class=\"display-title\">\r\n            <h1>");
            EndContext();
            BeginContext(153, 17, false);
#line 7 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
           Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(170, 48, true);
            WriteLiteral("</h1>\r\n        </div>\r\n        <div class=\"exit\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 218, "\"", 250, 3);
            WriteAttributeValue("", 228, "exit(", 228, 5, true);
#line 9 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
WriteAttributeValue("", 233, Model.ProductId, 233, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 249, ")", 249, 1, true);
            EndWriteAttribute();
            BeginContext(251, 15, true);
            WriteLiteral(">\r\n            ");
            EndContext();
            BeginContext(266, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4464595a31df405ea64e8b01ddc5e8cf", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(308, 151, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"item-display-grid\">\r\n            <section class=\"productDescribtion\">\r\n                <div class=\"productImg\">\r\n");
            EndContext();
#line 15 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
                     foreach (Image image in Model.Images)
                    {

#line default
#line hidden
            BeginContext(542, 85, true);
            WriteLiteral("                        <div class=\"img-display-frame\">\r\n                            ");
            EndContext();
            BeginContext(627, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ad60a3820d184e59bee3eb7c14f8e01a", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 637, "~/images/productImages/", 637, 23, true);
#line 18 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
AddHtmlAttributeValue("", 660, image.ImageUrl, 660, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 18 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
AddHtmlAttributeValue("", 682, image.ImageName, 682, 16, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(702, 34, true);
            WriteLiteral("\r\n                        </div>\r\n");
            EndContext();
#line 20 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
                    }

#line default
#line hidden
            BeginContext(759, 66, true);
            WriteLiteral("                </div>\r\n\r\n                <div class=\"dropdown\">\r\n");
            EndContext();
#line 24 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
                     if (Model.AspNetUserId != ViewBag.UserId)
                    {

#line default
#line hidden
            BeginContext(912, 81, true);
            WriteLiteral("                        <div class=\"custom-select\">\r\n                            ");
            EndContext();
            BeginContext(993, 224, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9abc91b24e7a4677b620780931bac089", async() => {
                BeginContext(1087, 34, true);
                WriteLiteral("\r\n                                ");
                EndContext();
                BeginContext(1121, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88c09fef31144feb86eebbf320978f75", async() => {
                    BeginContext(1145, 24, true);
                    WriteLiteral("choose an item to swapp!");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1178, 30, true);
                WriteLiteral("\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#line 27 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.ProductDropDownList as List<SelectListItem>;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1217, 34, true);
            WriteLiteral("\r\n                        </div>\r\n");
            EndContext();
#line 31 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"

                    }

#line default
#line hidden
            BeginContext(1276, 92, true);
            WriteLiteral("                </div>\r\n\r\n                <div class=\"productText\">\r\n                    <p>");
            EndContext();
            BeginContext(1369, 24, false);
#line 36 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
                  Write(Model.ProductDescription);

#line default
#line hidden
            EndContext();
            BeginContext(1393, 199, true);
            WriteLiteral("</p>\r\n                </div>\r\n\r\n\r\n            </section>\r\n            <section class=\"profileDisplay\">\r\n                <div class=\"profile-describtion\">\r\n                    <h4 class=\"profileName\">");
            EndContext();
            BeginContext(1593, 25, false);
#line 43 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
                                       Write(Model.AspNetUser.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1618, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1620, 25, false);
#line 43 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
                                                                  Write(Model.AspNetUser.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1645, 57, true);
            WriteLiteral("</h4>\r\n                    <h4 class=\"profileCity\">city: ");
            EndContext();
            BeginContext(1703, 21, false);
#line 44 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
                                             Write(Model.AspNetUser.City);

#line default
#line hidden
            EndContext();
            BeginContext(1724, 101, true);
            WriteLiteral("</h4>\r\n                </div>\r\n                <div class=\"profilePic-display\">\r\n                    ");
            EndContext();
            BeginContext(1825, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5193f1a7ff004990a2c7fc99cf30a8c9", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1835, "~/images/profilePics/", 1835, 21, true);
#line 47 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
AddHtmlAttributeValue("", 1856, Model.AspNetUser.ProfilePic, 1856, 28, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 47 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
AddHtmlAttributeValue("", 1891, Model.AspNetUser.UserName, 1891, 26, false);

#line default
#line hidden
#line 47 "C:\Users\jakob\source\repos\Swapp\Swapp\Views\Shared\_ProductDetailsDisplay.cshtml"
AddHtmlAttributeValue(" ", 1917, Model.AspNetUser.LastName, 1918, 26, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1967, 84, true);
            WriteLiteral("\r\n                </div>\r\n            </section>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591