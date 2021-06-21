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


/************Dashoard charts***************************************************************/

/********************************1st chart******************/

//Highcharts.chart('container', {
//    chart: {
//        type: 'column'
//    },
//    colors: [
//        '#3D76C3',
//        '#EE7D2F',
//        '#A5A5A5',
        
//    ],
//    title: {
//        text: 'Mobilization Report '
//    },
//    subtitle: {
//        text: '(Week wise, Branch Code and Value)'
//    },
//    xAxis: {
//        categories: [
//            'Category 1',
//            'Category 2',
//            'Category 3',
//            'Category 4'
//        ],
//        crosshair: true
//    },
//    yAxis: {

//        min: 0,
//        title: {
//            text: ''
//        }
//    },
//    tooltip: {
//        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
//        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
//            '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
//        footerFormat: '</table>',
//        shared: true,
//        useHTML: true
//    },
//    plotOptions: {
//        column: {
//            pointPadding: 0.1,
//            borderWidth: 0
//        }
//    },
//    series: [{
//        name: 'Series 1',
//        data: [49.9, 71.5, 106.4, 129.2]

//    }, {
//            name: 'Series 2',
//        data: [83.6, 78.8, 98.5, 93.4]

//    }, {
//            name: 'Series 3',
//        data: [42.4, 33.2, 34.5, 39.7]

//    }]
//});

/********************************2nd chart******************/

//Highcharts.chart('canvas', {

//    chart: {
//        type: 'column'
//    },
//    colors: [
//        '#3D76C3',
//        '#EE7D2F',

//    ],
//    title: {
//        text: 'Month Wise Disbursed Files and Total Amount'
//    },

//    xAxis: {
//        categories: [

//            'Category 1',
//            'Category 2',
//            'Category 3',
//            'Category 4'
//        ],
//    },

//    yAxis: {
//        allowDecimals: false,
//        min: 0,
//        title: {
//            text: ''
//        }
//    },

//    tooltip: {
//        formatter: function () {
//            return '<b>' + this.x + '</b><br/>' +
//                this.series.name + ': ' + this.y + '<br/>' +
//                'Total: ' + this.point.stackTotal;
//        }
//    },

//    plotOptions: {
//        column: {
//            stacking: 'normal'
//        }
//    },

//    series: [{
//        name: 'Series 1',
//        data: [2, 5, 6, 2, 1],
//        stack: 'female'
//    }, {
//            name: 'Series 2',
//        data: [3, 0, 4, 4, 3],
//        stack: 'female'
//    }]
//});


/********************************3rd chart******************/


    //Highcharts.chart('branch', {
    //    chart: {
    //        type: 'column'
    //    },
    //    colors: [
    //        '#3D76C3',
    //        '#EE7D2F',
    //        '#A5A5A5',

    //    ],
    //    title: {
    //        text: 'Branches Portfolio'
    //    },
    //    subtitle: {
    //        text: '(Applications, Total Amount, Branch Code)'
    //    },
    //    xAxis: {
    //        categories: [
    //            'Category 1',
    //            'Category 2',
    //            'Category 3',
    //            'Category 4'
    //        ],
    //        crosshair: true
    //    },
    //    yAxis: {

    //        min: 0,
    //        title: {
    //            text: ''
    //        }
    //    },
    //    tooltip: {
    //        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
    //        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
    //            '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
    //        footerFormat: '</table>',
    //        shared: true,
    //        useHTML: true
    //    },
    //    plotOptions: {
    //        column: {
    //            pointPadding: 0.1,
    //            borderWidth: 0
    //        }
    //    },
    //    series: [{
    //        name: 'Series 1',
    //        data: [4, 6, 4, 2]

    //    }, {
    //        name: 'Series 2',
    //        data: [6, 8, 5, 4]

    //    }, {
    //        name: 'Series 3',
    //        data: [4, 3, 3, 13]

    //    }]
    //});
   
/********************************4th chart******************/
//Highcharts.chart('bankprt', {
//    chart: {
//        plotBackgroundColor: null,
//        plotBorderWidth: null,
//        plotShadow: false,
//        type: 'pie'
//    },
//    colors: [
//        '#3D76C3',
//        '#EE7D2F',
//        '#A5A5A5',
//        '#FFC003',

//    ],
//    title: {
//        text: 'Bank Portfolio'
//    },
//    tooltip: {
//        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
//    },
//    plotOptions: {
//        pie: {
//            allowPointSelect: true,
//            cursor: 'pointer',
//            dataLabels: {
//                enabled: true,
//                format: '<b>{point.name}</b>: {point.percentage:.1f} %'
//            }
//        }
//    },
//    series: [{
//        name: '',
//        colorByPoint: true,
//        data: [{
//            name: '1st Qtr',
//            y: 50,
//            sliced: true,
//            selected: true
//        },  {
//                name: '2nd Qtr',
//            y: 15
//            },
//            {
//                name: '3rd  Qtr',
//                y: 15
//            },
//            {
//                name: '4th  Qtr',
//            y: 18
//        }]
//    }]
//});

/********************************end charts******************/


$(document).ready(function () {
    var trigger = $('.hamburger'),
        overlay = $('.overlay'),
        isClosed = false;

    trigger.click(function () {
        hamburger_cross();
    });

    function hamburger_cross() {

        if (isClosed == true) {
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            isClosed = false;
        } else {
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
        }
    }

    $('[data-toggle="offcanvas"]').click(function () {
        $('#wrapper').toggleClass('toggled');
    });
});


(function ($) {
    "use strict";

    /*==================================================================
    [ Focus Contact2 ]*/
    $('.input100').each(function () {
        $(this).on('blur', function () {
            if ($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })
    })

    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit', function () {
        var check = true;

        for (var i = 0; i < input.length; i++) {
            if (validate(input[i]) == false) {
                showValidate(input[i]);
                check = false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });

    function validate(input) {
        if ($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if ($(input).val().trim() == '') {
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }


})(jQuery);
(function ($) {
    // USE STRICT
    "use strict";

    $(document).ready(function () {

        var selector_map = $('#google_map');
        var img_pin = selector_map.attr('data-pin');
        var data_map_x = selector_map.attr('data-map-x');
        var data_map_y = selector_map.attr('data-map-y');
        var scrollwhell = selector_map.attr('data-scrollwhell');
        var draggable = selector_map.attr('data-draggable');

        if (img_pin == null) {
            img_pin = 'images/icons/location.png';
        }
        if (data_map_x == null || data_map_y == null) {
            data_map_x = 40.007749;
            data_map_y = -93.266572;
        }
        if (scrollwhell == null) {
            scrollwhell = 0;
        }

        if (draggable == null) {
            draggable = 0;
        }

        var style = [
            {
                "featureType": "all",
                "elementType": "labels.text.fill",
                "stylers": [
                    {
                        "saturation": 36
                    },
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 40
                    }
                ]
            },
            {
                "featureType": "all",
                "elementType": "labels.text.stroke",
                "stylers": [
                    {
                        "visibility": "on"
                    },
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 16
                    }
                ]
            },
            {
                "featureType": "all",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "administrative",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 20
                    }
                ]
            },
            {
                "featureType": "administrative",
                "elementType": "geometry.stroke",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 17
                    },
                    {
                        "weight": 1.2
                    }
                ]
            },
            {
                "featureType": "landscape",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 20
                    }
                ]
            },
            {
                "featureType": "poi",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 21
                    }
                ]
            },
            {
                "featureType": "road.highway",
                "elementType": "geometry.fill",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 17
                    }
                ]
            },
            {
                "featureType": "road.highway",
                "elementType": "geometry.stroke",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 29
                    },
                    {
                        "weight": 0.2
                    }
                ]
            },
            {
                "featureType": "road.arterial",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 18
                    }
                ]
            },
            {
                "featureType": "road.local",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 16
                    }
                ]
            },
            {
                "featureType": "transit",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 19
                    }
                ]
            },
            {
                "featureType": "water",
                "elementType": "geometry",
                "stylers": [
                    {
                        "color": "#000000"
                    },
                    {
                        "lightness": 17
                    }
                ]
            }
        ];

        var latitude = data_map_x,
            longitude = data_map_y,
            map_zoom = 14;

        var locations = [
            ['Welcome', latitude, longitude, 2]
        ];

        if (selector_map !== undefined) {
            var map = new google.maps.Map(document.getElementById('google_map'), {
                zoom: 13,
                scrollwheel: scrollwhell,
                navigationControl: true,
                mapTypeControl: false,
                scaleControl: false,
                draggable: draggable,
                styles: style,
                center: new google.maps.LatLng(latitude, longitude),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
        }

        var infowindow = new google.maps.InfoWindow();

        var marker, i;

        for (i = 0; i < locations.length; i++) {

            marker = new google.maps.Marker({
                position: new google.maps.LatLng(locations[i][1], locations[i][2]),
                map: map,
                icon: img_pin
            });

            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent(locations[i][0]);
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }

    });

})(jQuery);