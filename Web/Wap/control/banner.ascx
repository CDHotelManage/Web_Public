<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="banner.ascx.cs" Inherits="CdHotelManage.Web.Wap.control.banner" %>
<link rel="stylesheet" href="../css/jquery.mobile.structure-1.4.2.min.css" />
<div role="main" class="_kmain">
        <div class="slider">
            <div class="swiper-container" style="cursor: -webkit-grab;">
                <div class="swiper-wrapper" style="width: 8320px; height: 140px; transform: translate3d(-3328px, 0px, 0px); -webkit-transform: translate3d(-3328px, 0px, 0px); transition-duration: 0s; -webkit-transition-duration: 0s;">  
                    <asp:Repeater ID="rptBanner" runat="server">
                        <ItemTemplate>
                            <div class="swiper-slide" style="width: 1664px; height: 140px;">
                                <a href="../order_room/bannerDetails.aspx" class="k-links ui-link">
                                    <img src='<%#Eval("imgurl") %>' width="100%" height="140">
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                   </div>
            </div>
            <div class="pagination">
            <span class="swiper-pagination-switch"></span>
            <span class="swiper-pagination-switch swiper-visible-switch swiper-active-switch"></span>
            <span class="swiper-pagination-switch"></span>
            </div>
        </div>
        <div class="clear"></div>
        <!-- 滚动结束 -->
		
    
     <script src="../js/idangerous.swiper-2.1.min.js"></script> 
     <link rel="stylesheet" href="../css/idangerous.swiper.css" />
     <link rel="stylesheet" href="../css/slider.app.css" />
   
    
    <script type="text/javascript">
        var mySwiper = new Swiper('.swiper-container', { pagination: '.pagination', grabCursor: true, paginationClickable: true, autoplay: 2500, loop: true });
	</script>
</div>