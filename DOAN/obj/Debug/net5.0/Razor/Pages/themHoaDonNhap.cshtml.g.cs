#pragma checksum "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\themHoaDonNhap.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e0978452718f1c0805468e7533a16ccc17827f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(DOAN.Pages.Pages_themHoaDonNhap), @"mvc.1.0.razor-page", @"/Pages/themHoaDonNhap.cshtml")]
namespace DOAN.Pages
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
#line 1 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\_ViewImports.cshtml"
using DOAN;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e0978452718f1c0805468e7533a16ccc17827f0", @"/Pages/themHoaDonNhap.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"316d1e352639401dff0594474ca7adbf6cb396e5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_themHoaDonNhap : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e0978452718f1c0805468e7533a16ccc17827f03301", async() => {
                WriteLiteral("\r\n    <label>Mã hóa đơn</label><br>\r\n    <input type=\"text\" name=\"maHD\"");
                BeginWriteAttribute("value", " value=\"", 139, "\"", 147, 0);
                EndWriteAttribute();
                WriteLiteral(" pattern=\"^[^\\s]+(\\s+[^\\s]+)*$\" required><br>\r\n    <label>Ngày hóa đơn</label><br>\r\n    <input type=\"text\" name=\"ngayHD\"");
                BeginWriteAttribute("value", " value=\"", 268, "\"", 276, 0);
                EndWriteAttribute();
                WriteLiteral(@" pattern=""^(?:(?:31(\/)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"" required><br>
    <label>Mã mặt hàng</label><br>
    <input type=""text"" name=""maMH""");
                BeginWriteAttribute("value", " value=\"", 683, "\"", 691, 0);
                EndWriteAttribute();
                WriteLiteral(" pattern=\"^[^\\s]+(\\s+[^\\s]+)*$\" required><br>\r\n    <label>Số lượng</label><br>\r\n    <input type=\"text\" name=\"soLuong\"");
                BeginWriteAttribute("value", " value=\"", 809, "\"", 817, 0);
                EndWriteAttribute();
                WriteLiteral(" pattern=\"^[0-9]*$\" required><br>\r\n    <label>Đơn giá nhập</label><br>\r\n    <input type=\"text\" name=\"donGia\"");
                BeginWriteAttribute("value", " value=\"", 926, "\"", 934, 0);
                EndWriteAttribute();
                WriteLiteral(" pattern=\"^[0-9]*$\" required><br><br>\r\n    <button type=\"submit\" name=\"suKien\" value=\"Thêm\">Thêm</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\TRONG\Desktop\DoAn_LTHDT\DOAN\Pages\themHoaDonNhap.cshtml"
Write(Model.ketQua);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br>\r\n<a href=\"HoaDonNhap\"><button type=\"button\">Tìm Kiếm</button></a>\r\n<a href=\"index\"><button type=\"button\">Index</button></a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DOAN.Pages.themHoaDonNhapModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DOAN.Pages.themHoaDonNhapModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DOAN.Pages.themHoaDonNhapModel>)PageContext?.ViewData;
        public DOAN.Pages.themHoaDonNhapModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591