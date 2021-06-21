/*======================================================
	Javascript custom functions
=======================================================*/
/*
=======================================
	Develope by shahzadali.eu5.org
=======================================
*/
jQuery(document).ready(function ($) {
	'use strict'

	/* =======================================================================
		  		 Chosen Script 
	   =======================================================================
	*/	
		if($(".select-menu").length){
			$(".select-menu").chosen()
		}

	if($('.input-effect input').length){
		$(".input-effect input").focusout(function(){
			if($(this).val() != ""){
				$(this).addClass("has-content");
			}else{
				$(this).removeClass("has-content");
			}
		});
	}

 	if($('.eft-1').length){
		$('.eft-1').on('mouseenter', function(e) {
					var parentOffset = $(this).offset(),
			  		relX = e.pageX - parentOffset.left,
			  		relY = e.pageY - parentOffset.top;
					$(this).find('span').css({top:relY, left:relX})
			});
			
			$("[href='#']").click(function(){return false});
	}
	if($('.filter_tab').length){
		$(".filter_tab").champ({
		    plugin_type: "tab",
		    side: "left",
		    active_tab: "1",
		    multiple_tabs: "true",
		    controllers: "false"
		});
	}
	/*$(window).load(function() { // makes sure the whole site is loaded
		$('#status').fadeOut(); // will first fade out the loading animation
		$('#preloader').delay(100).fadeOut('slow'); // will fade out the white DIV that covers the website.
		$('body').delay(500).css({'overflow':'visible'});
	})*/
    
});