#pragma checksum "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e39cd64a839e192405cdabb9fd8bc3f0fe207364"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_ProcessResponse), @"mvc.1.0.view", @"/Views/User/ProcessResponse.cshtml")]
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
#line 1 "F:\Project\ReturnOrderPortal\Views\_ViewImports.cshtml"
using ReturnOrderPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Project\ReturnOrderPortal\Views\_ViewImports.cshtml"
using ReturnOrderPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e39cd64a839e192405cdabb9fd8bc3f0fe207364", @"/Views/User/ProcessResponse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"850e3eaf546a47a31ba688e63823c53c08ba9cc2", @"/Views/_ViewImports.cshtml")]
    public class Views_User_ProcessResponse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReturnOrderPortal.Models.ProcessResponse>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml"
  
    ViewData["Title"] = "ProcessResponse";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ProcessResponse</h1>\r\n\r\n\r\n\r\n<h3>Request Id:");
#nullable restore
#line 11 "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml"
          Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<br />\r\n<h3>Processing Charge:");
#nullable restore
#line 13 "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml"
                 Write(Model.ProcessingCharge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<br />\r\n<h3>PackagingAndDeliveryCharge:");
#nullable restore
#line 15 "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml"
                          Write(Model.PackagingAndDeliveryCharge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<br />\r\n<h3>Date Of Delivery:");
#nullable restore
#line 17 "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml"
                Write(Model.DateOfDelivery);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n");
#nullable restore
#line 19 "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml"
 using (Html.BeginForm("Confirmation", "User", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"submit\" value=\"Confirm Payment\" />\r\n");
#nullable restore
#line 22 "F:\Project\ReturnOrderPortal\Views\User\ProcessResponse.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReturnOrderPortal.Models.ProcessResponse> Html { get; private set; }
    }
}
#pragma warning restore 1591
