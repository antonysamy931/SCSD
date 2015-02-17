// JavaScript Document
function menu() {
    var winWidth = $(window).width();
    var left = "0";
    var padLeft = "220px";
    var className = "menuHide";

    if (winWidth < 801) {
        left = "-220px";
        padLeft = "0";
        className = "menuShow";
    }

    $("#sidebar").stop().animate({"left": left}, 300);
    $("#container").stop().animate({"padding-left": padLeft}, 300);
    $("#menuToggle").removeClass().addClass(className);
}

function containerHeight() {
	var winHeight = $(window).height();
	var headerHeight = $("#main-navbar").outerHeight();
	var contanerHeight = winHeight - headerHeight;
	var footerHeight = $("#footer").outerHeight();
	$("#container, #dashboard").css({'min-height': contanerHeight, 'padding-bottom': footerHeight });
	$("#sidebar").css("top", headerHeight);
}

$(document).ready(function() {
	
	$(".searchToggle").click(function () {
		$(".search-inner").slideToggle(300);
		$(".searchToggle .glyphicon").toggleClass("glyphicon-triangle-bottom glyphicon-triangle-top");
	});
	
	$(document).on( "click","#menuToggle", function(e) {
		
		e.preventDefault();
		var left="-220px";
		var padLeft="0";
		
		if($(this).hasClass("menuShow")) {
			 left="0px";
		     padLeft="220px";
		}
		
		$("#sidebar").stop().animate({"left":left}, 300);
		$("#container").stop().animate({"padding-left": padLeft }, 300,
			function(){
				 $("#menuToggle").toggleClass("menuShow menuHide");
		    });
	});	
		
	menu();
	containerHeight();
	
	$(window).resize(function() {
		menu();
		containerHeight();
	});
	
});