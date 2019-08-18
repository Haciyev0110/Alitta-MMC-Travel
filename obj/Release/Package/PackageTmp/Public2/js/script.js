(function($) {
	
	"use strict";
	
	
	//Hide Loading Box (Preloader)
	function handlePreloader() {
		if($('.preloader').length){
			$('.preloader').delay(200).fadeOut(500);
		}
	}
	
	
	var navcollapse = $('.main-menu .navigation li');
        navcollapse.hover(function() {
            $(this).children('.submenu').stop(true, false, true).slideToggle(300);
        });
	//Submenu Dropdown Toggle
	if($('.main-menu .mobile-menu li.dropdown ul').length){
		$('.main-menu .mobile-menu li.dropdown').append('<div class="dropdown-btn"></div>');
		
		//Dropdown Button
		$('.main-menu .mobile-menu li.dropdown .dropdown-btn').on('click', function() {
			$(this).prev('ul').slideToggle(500);
		});
	}

	function stickyHeader () {
		if ($('.stricky').length) {
			var strickyScrollPos = 100;
			if($(window).scrollTop() > strickyScrollPos) {
				$('.stricky').removeClass('fadeIn animated');
		      	$('.stricky').addClass('stricky-fixed fadeInDown animated');
		      	$('.scroll-to-top').fadeIn(500);
			}
			else if($(this).scrollTop() <= strickyScrollPos) {
				$('.stricky').removeClass('stricky-fixed fadeInDown animated');
		      	$('.stricky').addClass('slideIn animated');
		      	$('.scroll-to-top').fadeOut(500);
			}
		};
	}

	
	
	function galleryMasonaryLayout() {
	    if ($('.masonary-layout').length) {
	        $('.masonary-layout').isotope({
	            layoutMode: 'masonry'
	        });
	    }

	    if ($('.post-filter').length) {
	        $('.post-filter li').children('span').on('click', function() {
	            var Self = $(this);
	            var selector = Self.parent().attr('data-filter');
	            $('.post-filter li').children('span').parent().removeClass('active');
	            Self.parent().addClass('active');


	            $('.filter-layout').isotope({
	                filter: selector,
	                animationOptions: {
	                    duration: 500,
	                    easing: 'linear',
	                    queue: false
	                }
	            });
	            return false;
	        });
	    }

	    if ($('.post-filter.has-dynamic-filter-counter').length) {
	        // var allItem = $('.single-filter-item').length;

	        var activeFilterItem = $('.post-filter.has-dynamic-filter-counter').find('li');

	        activeFilterItem.each(function() {
	            var filterElement = $(this).data('filter');
	            console.log(filterElement);
	            var count = $('.gallery-content').find(filterElement).length;

	            $(this).children('span').append('<span class="count"><b>' + count + '</b></span>');
	        });
	    };
	}


	//Accordion Box
	if ($('.accordion-box').length) {
	        $('.accordion-box .acc-btn').on('click', function() {
	            if ($(this).hasClass('active') !== true) {
	                $('.accordion-box .acc-btn').removeClass('active');
	            }

	            if ($(this).next('.acc-content').is(':visible')) {
	                $(this).removeClass('active');
	                $(this).next('.acc-content').slideUp(500);
	            } else {
	                $(this).addClass('active');
	                $('.accordion-box .acc-content').slideUp(500);
	                $(this).next('.acc-content').slideDown(500);
	            }
	        });
	    }
	


	 // Scroll to a Specific Div
	if($('.scroll-to-target').length){
		$(".scroll-to-target").on('click', function() {
			var target = $(this).attr('data-target');
		   // animate
		   $('html, body').animate({
			   scrollTop: $(target).offset().top
			 }, 1000);
	
		});
	}



	//gallery-slider
	if ($('.gallery-slider').length) {
		$('.gallery-slider').owlCarousel({
			loop:true,
			margin:0,
			nav:true,
			smartSpeed: 3000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				400:{
					items:1
				},
				600:{
					items:2
				},
				800:{
					items:3
				},
				1200:{
					items:4
				}
			}
		});    		
	}

	// sponsors-slider
	if ($('.brand-slider').length) {
		$('.brand-slider').owlCarousel({
			loop:true,
			margin:30,
			nav:true,
			smartSpeed: 3000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				400:{
					items:2
				},
				600:{
					items:3
				},
				800:{
					items:4
				},
				1200:{
					items:5
				}
			}
		});    		
	}

	// sponsors-slider
	if ($('.project-slid').length) {
		$('.project-slid').owlCarousel({
			loop:true,
			margin:0,
			nav:true,
			smartSpeed: 3000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				400:{
					items:1
				},
				600:{
					items:1
				},
				800:{
					items:1
				},
				1200:{
					items:1
				}
			}
		});    		
	}


	//Four Column Carousel Slider
	if ($('.four-column-carousel').length) {
		$('.four-column-carousel').owlCarousel({
			loop:true,
			margin:30,
			nav:true,
			smartSpeed: 2000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				600:{
					items:2
				},
				800:{
					items:3
				},
				1070:{
					items:4
				}
			}
		});    		
	}


	
	//Two Column Carousel Slider
	if ($('.two-column-carousel').length) {
		$('.two-column-carousel').owlCarousel({
			loop:true,
			margin:40,
			nav:true,
			smartSpeed: 3000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-right"></span>', '<span class="fa fa-angle-left"></span>' ],
			responsive:{
				0:{
					items:1
				},
				480:{
					items:1
				},
				600:{
					items:2
				},
				800:{
					items:2
				},
				1024:{
					items:2
				}
			}
		});    		
	}

	//Three Column Carousel Slider
	if ($('.three-column-carousel').length) {
		$('.three-column-carousel').owlCarousel({
			loop:true,
			margin:30,
			nav:true,
			smartSpeed: 3000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				480:{
					items:1
				},
				600:{
					items:2
				},
				800:{
					items:2
				},
				1024:{
					items:3
				}
			}
		});    		
	}

	//testimonial-slider
	if ($('.testimonials-slider').length) {
		$('.testimonials-slider').owlCarousel({
			loop:true,
			margin:30,
			nav:true,
			smartSpeed: 3000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				480:{
					items:1
				},
				600:{
					items:1
				},
				800:{
					items:1
				},
				1024:{
					items:1
				}
			}
		});    		
	}


	if ($('.brand-slider').length) {
		$('.brand-slider').owlCarousel({
			loop:true,
			margin:30,
			nav:true,
			smartSpeed: 3000,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				480:{
					items:2
				},
				600:{
					items:3
				},
				800:{
					items:4
				},
				1024:{
					items:5
				}
			}
		});    		
	}
	
	//Single Item Slider
	if ($('.single-item-carousel').length) {
		$('.single-item-carousel').owlCarousel({
			loop:true,
			margin:0,
			nav:true,
			smartSpeed: 700,
			autoplay: 4000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				600:{
					items:1
				},
				1200:{
					items:1
				}
			}
		});    		
	}


	//Main Slider Carousel
	if ($('.main-slider-carousel').length) {
		$('.main-slider-carousel').owlCarousel({
			loop:true,
			margin:0,
			nav:true,
			animateOut: 'slideOutDown',
    		animateIn: 'fadeIn',
    		active: true,
			smartSpeed: 1000,
			autoplay: 5000,
			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],
			responsive:{
				0:{
					items:1
				},
				600:{
					items:1
				},
				1200:{
					items:1
				}
			}
		});    		
	}
	

	//Tabs Box
	if($('.tabs-box').length){
		
		//Tabs
		$('.tabs-box .tab-buttons .tab-btn').on('click', function(e) {
			
			e.preventDefault();
			var target = $($(this).attr('data-tab'));
			
			target.parents('.tabs-box').find('.tab-buttons').children('.tab-btn').removeClass('active-btn');
			$(this).addClass('active-btn');
			target.parents('.tabs-box').find('.tabs-content').find('.tab').fadeOut(0);
			target.parents('.tabs-box').find('.tabs-content').find('.tab').removeClass('active-tab');
			$(target).fadeIn(300);
			$(target).addClass('active-tab');
		});
		
	}

	
	//Tabbed Floor Plans Function
	if($('.tabbed-floor-plans .floor-btn').length){
		
		//Floor Details Hide Show
		$('.tabbed-floor-plans .floor-btn').on('click', function(e) {
			e.preventDefault();
			var target = $($(this).attr('href'));
			$('.tabbed-floor-plans .floor-btn').removeClass('active');
			$(this).addClass('active');
			$('.tabbed-floor-plans .floor-details').removeClass('collapsed');
			$('.tabbed-floor-plans .floor-details ').fadeOut(0);
			$(target).fadeIn(300);
		});
		
	}

	// Language switcher
	function languageSwitcher() {

	    if ($("#polyglot-language-options").length) {
	        $('#polyglotLanguageSwitcher').polyglotLanguageSwitcher({
	            effect: 'slide',
	            animSpeed: 150,
	            testMode: true,
	            onChange: function(evt) {
	                    alert("The selected language is: " + evt.selectedItem);
	                }

	        });
	    };
	}

	//Progress Bar / Levels
	if($('.progress-levels .progress-box .bar-fill').length){
		$(".progress-box .bar-fill").each(function() {
			var progressWidth = $(this).attr('data-percent');
			$(this).css('width',progressWidth+'%');
			$(this).parents('.progress-box').children('.percent').html(progressWidth+'%');
		});
	}

	

	//Search Box Toggle
	if($('.search-toggle').length){
		//Dropdown Button
		$('.search-toggle').on('click', function() {
		   $(this).toggleClass('active');
		   $(this).next('.search-box').toggleClass('now-visible');
		});
	}
	

	// 4. select menu
	function selectMenu () {
		if ($('.select-menu').length) {
			$('.select-menu').selectmenu();
		};
	}
	
	
	//LightBox / Fancybox
	if($('.lightbox-image').length) {
		$('.lightbox-image').fancybox({
			openEffect  : 'elastic',
			closeEffect : 'elastic',
			helpers : {
				media : {}
			}
		});
	}
	
	//=== Cart Touch Spin ===
	function cartTouchSpin() {
	    if ($('.quantity-spinner').length) {
	        $("input.quantity-spinner").TouchSpin({
	            verticalbuttons: true
	        });
	    }
	}


	//=== Contact Form Validation ===
    if($("#contact-form").length){
        $("#contact-form").validate({
            submitHandler: function(form) {
              var form_btn = $(form).find('button[type="submit"]');
              var form_result_div = '#form-result';
              $(form_result_div).remove();
              form_btn.before('<div id="form-result" class="alert alert-success" role="alert" style="display: none;"></div>');
              var form_btn_old_msg = form_btn.html();
              form_btn.html(form_btn.prop('disabled', true).data("loading-text"));
              $(form).ajaxSubmit({
                dataType:  'json',
                success: function(data) {
                  if( data.status == 'true' ) {
                    $(form).find('.form-control').val('');
                  }
                  form_btn.prop('disabled', false).html(form_btn_old_msg);
                  $(form_result_div).html(data.message).fadeIn('slow');
                  setTimeout(function(){ $(form_result_div).fadeOut('slow') }, 6000);
                }
              });
            }
        });
    }

    

    function priceFilter () {
		if($('.range-slider-price').length){

			var priceRange = document.getElementById('range-slider-price');

			noUiSlider.create(priceRange, {
				start: [ 15, 45 ],
				limit: 99,
				behaviour: 'drag',
				connect: true,
				range: {
					'min': 15,
					'max': 99
				}
			});

			var limitFieldMin = document.getElementById('min-value-rangeslider');
			var limitFieldMax = document.getElementById('max-value-rangeslider');
			
			priceRange.noUiSlider.on('update', function( values, handle ){
				(handle ? limitFieldMax : limitFieldMin).value = values[handle];
			});
		};
	}
	
	if ($('.our-team .bxslider').length) {
		$('.our-team .bxslider').bxSlider({
	        nextSelector: '.our-team #slider-next',
	        prevSelector: '.our-team #slider-prev',
	        nextText: '<i class="fa fa-angle-right"></i>',
	        prevText: '<i class="fa fa-angle-left"></i>',
	        mode: 'fade',
	        auto: 'true',
	        speed: '700',
	        pagerCustom: '.our-team .slider-pager .thumb-box'
	    });
	};
	
	//Gallery Popup Hide / Show
	if($('.has-gallery-popup').length){
		
		//Show Gallery Popup
		$('.has-gallery-popup').on('click', function(e) {
			e.preventDefault();
			var target = $($(this).attr('href'));
			$('body').addClass('popup-visible');
			$(target).addClass('now-visible');
		});
		
		//Show Gallery Popup
		$('.gallery-box .btn-close,.gallery-box .bg-fade-layer').on('click', function() {
			$('.gallery-box').removeClass('now-visible');
			$('body').removeClass('popup-visible');
		});
		
	}

	//Gallery Popup Slider / Vertical Gallery Slider
	if($('.vertical-slider').length) {
		var slider = new MasterSlider();
		slider.setup('masterslider' , {
			width:850,
			height:470,
			space:10,
			view:'basic',
			dir:'v'
		});
		slider.control('arrows');	
		slider.control('scrollbar' , {dir:'v'});	
		slider.control('circletimer' , {color:"#FFFFFF" , stroke:9});
		slider.control('thumblist' , {autohide:false ,dir:'v'});
	}




	// Fact Counter
	function factCounter() {
		if($('.fact-counter').length){
			$('.fact-counter .column.animated').each(function() {
		
				var $t = $(this),
					n = $t.find(".count-text").attr("data-stop"),
					r = parseInt($t.find(".count-text").attr("data-speed"), 10);
					
				if (!$t.hasClass("counted")) {
					$t.addClass("counted");
					$({
						countNum: $t.find(".count-text").text()
					}).animate({
						countNum: n
					}, {
						duration: r,
						easing: "linear",
						step: function() {
							$t.find(".count-text").text(Math.floor(this.countNum));
						},
						complete: function() {
							$t.find(".count-text").text(this.countNum);
						}
					});
				}
				
			});
		}
	}

	  //13. Countdown Timer
	if ($('.countdown').length) {
	    $('.countdown').countdown('2018/1/1', function (event) {
	        var $this = $(this).html(event.strftime('' + '<div class="counter-column"><span class="count">%D</span><br>Days</div> ' + '<div class="counter-column"><span class="count">%H</span><span class="colon"></span><br>Hours</div>  ' + '<div class="counter-column"><span class="count">%M</span><span class="colon"></span><br>Mutines</div>  ' + '<div class="counter-column"><span class="count">%S</span><span class="colon"></span><br>Seconds</div>'));
	    });
	}

	function customTabProductPageTab () {
	    if ($('.product-details-tab-title').length) {
	        var tabWrap = $('.product-details-tab-content');
	        var tabClicker = $('.product-details-tab-title ul li');
	        
	        tabWrap.children('div').hide();
	        tabWrap.children('div').eq(0).show();
	        tabClicker.on('click', function() {
	            var tabName = $(this).data('tab-name');
	            tabClicker.removeClass('active');
	            $(this).addClass('active');
	            var id = '#'+ tabName;
	            tabWrap.children('div').not(id).hide();
	            tabWrap.children('div'+id).fadeIn('500');
	            return false;
	        });        
	    }
	}
	
	// Scroll to a Specific Div
	if($('.scroll-to-target').length){
		$(".scroll-to-target").on('click', function() {
			var target = $(this).attr('data-target');
		   // animate
		   $('html, body').animate({
			   scrollTop: $(target).offset().top
			 }, 10);
	
		});
	}

	
	// Elements Animation
	if($('.wow').length){
		var wow = new WOW(
		  {
			boxClass:     'wow',      // animated element css class (default is wow)
			animateClass: 'animated', // animation css class (default is animated)
			offset:       0,          // distance to the element when triggering the animation (default is 0)
			mobile:       false,       // trigger animations on mobile devices (default is true)
			live:         true       // act on asynchronously loaded content (default is true)
		  }
		);
		wow.init();
	}


	// Chart function 
	function chartBox() {
	    if ($("#chartbar").length) {
	        var chart = new CanvasJS.Chart("chartbar", {

	            data: [ //array of dataSeries     
	                { //dataSeries - first quarter
	                    /*** Change type "column" to "bar", "area", "line" or "pie"***/
	                    type: "column",
	                    showInLegend: false,
	                    color: "#000000",
	                    dataPoints: [
	                        { label: "2014", y: 100 },
	                        { label: "2015", y: 75 },
	                        { label: "2016", y: 50 },
	                        { label: "2017", y: 95 }
	                    ]
	                },

	                { //dataSeries - second quarter

	                    type: "column",
	                    showInLegend: false,
	                    color: "#e5e5e5",
	                    dataPoints: [
	                        { label: "2014", y: 90 },
	                        { label: "2015", y: 65 },
	                        { label: "2016", y: 40 },
	                        { label: "2017", y: 75 }
	                    ]
	                }
	            ],
	            axisY: {
	                tickLength: 0,
	                gridColor: "#fbfcfc",
	                interval: 25,
	                lineColor: "transparent"
	            },
	            axisX: {
	                tickLength: 10,
	                gridColor: "transparent",
	                lineColor: "transparent",
	                tickColor: "transparent"
	            },
	        });

	        chart.render();
	    }
	}


	// Chart function Two 
	function chartBoxTwo() {
	    if ($("#chartbarTwo").length) {
	        var chart = new CanvasJS.Chart("chartbarTwo", {

	            data: [ //array of dataSeries     
	                { //dataSeries - first quarter
	                    /*** Change type "column" to "bar", "area", "line" or "pie"***/
	                    type: "column",
	                    showInLegend: false,
	                    color: "#1f2d42",
	                    dataPoints: [
	                        { label: "2009", y: 100 },
	                        { label: "2010", y: 75 },
	                        { label: "2011", y: 50 },
	                        { label: "2012", y: 75 },
	                        { label: "2013", y: 50 },
	                        { label: "2014", y: 60 },
	                        { label: "2015", y: 40 },
	                        { label: "2016", y: 70 },
	                        { label: "2017", y: 60 }
	                    ]
	                },

	                { //dataSeries - second quarter

	                    type: "column",
	                    showInLegend: false,
	                    color: "#e5e5e5",
	                    dataPoints: [
	                        { label: "2009", y: 90 },
	                        { label: "2010", y: 65 },
	                        { label: "2011", y: 40 },
	                        { label: "2012", y: 65 },
	                        { label: "2013", y: 55 },
	                        { label: "2014", y: 65 },
	                        { label: "2015", y: 85 },
	                        { label: "2016", y: 55 },
	                        { label: "2017", y: 75 }
	                    ]
	                }
	            ],
	            axisY: {
	                tickLength: 0,
	                gridColor: "#fbfcfc",
	                interval: 25,
	                lineColor: "transparent"
	            },
	            axisX: {
	                tickLength: 10,
	                gridColor: "transparent",
	                lineColor: "transparent",
	                tickColor: "transparent"
	            },
	        });

	        chart.render();
	    }
	}


	// Area Chart function
	function areaChart() {
	    if ($("#area-chart").length) {
	        var chart = new CanvasJS.Chart("area-chart", {

	            data: [{
	                    type: "splineArea",
	                    color: "#e5e5e5",
	                    fillOpacity: 1,
	                    markerBorderColor: "#fff",
	                    markerColor: "#9185c2",
	                    markerSize: 10,
	                    dataPoints: [
	                        { x: (0), y: 17 },
	                        { x: (1), y: 10 },
	                        { x: (2), y: 13 },
	                        { x: (3), y: 18 },
	                        { x: (4), y: 11 },
	                        { x: (5), y: 15 },
	                        { x: (6), y: 19 },
	                        { x: (7), y: 14 }
	                    ]
	                }, {
	                    type: "splineArea",
	                    color: "rgb(110, 140, 215)",
	                    fillOpacity: 1,
	                    markerBorderColor: "#222",
	                    markerColor: "#222",
	                    markerSize: 10,
	                    dataPoints: [
	                        { x: (0), y: 4 },
	                        { x: (1), y: 6 },
	                        { x: (2), y: 4 },
	                        { x: (3), y: 10 },
	                        { x: (4), y: 11 },
	                        { x: (5), y: 8 },
	                        { x: (6), y: 9 },
	                        { x: (7), y: 12 }
	                    ]
	                }

	            ]
	        });

	        chart.render();
	    }
	}


	// Doughnut Charts 
	function doughnutChartBox() {
	    if ($('#doughnut-chartBox').length) {
	        var ctx = $("#doughnut-chartBox");
	        var myDoughnutChart = new Chart(ctx, {
	            type: 'doughnut',
	            data: {
	                labels: [
	                    "58%",
	                    "22%",
	                    "20%"
	                ],
	                datasets: [{
	                    data: [300, 50, 100],
	                    backgroundColor: [
	                        "#121d2f",
	                        "#36a1e9",
	                        "#9185c2"
	                    ],
	                    hoverBackgroundColor: [
	                        "#121d2f",
	                        "#36a1e9",
	                        "#9185c2"
	                    ],
	                    hoverBorderColor: [
	                        "#fff",
	                        "#fff",
	                        "#fff"
	                    ]
	                }]
	            },
	            option: {
	                position: "left",
	                responsive: true,
	            }
	        });
	    };
	}




	function menuScroll () {
  		if ($('.menu_fixed.header-lower').length) {
    		var sticky = $('.menu_fixed.header-lower'),
       	 		scroll = $(window).scrollTop();

   	 		if (scroll >= 190) sticky.addClass('fixed');
   			else sticky.removeClass('fixed');
    
  		};
	}



	function swithcerMenu () {
	  	if ($('.switch_menu').length) {

	    	$('.switch_btn button').on('click', function(){
	      	$('.switch_menu').toggle(300)
	    	});

	    	$("#myonoffswitch").on('click', function(){
	        $(".header-lower").toggleClass("menu_fixed");
	        $(".header-lower").toggleClass("fixed");
	    	});

	    	$("#boxed").on('click', function(){
	      	$(".layout_changer").addClass("home_boxed");
	    	});
	    	$("#full_width").on('click', function(){
	      	$(".layout_changer").removeClass("home_boxed");
	    	});
	    	$(".bg1").on('click', function(){
	      	$(".home_boxed").addClass("bg1");
	      	$(".home_boxed").removeClass("bg2 bg3 bg4");
	    	});
	    	$(".bg2").on('click', function(){
	      	$(".home_boxed").addClass("bg2");
	      	$(".home_boxed").removeClass("bg1 bg3 bg4");
	    	});
	    	$(".bg3").on('click', function(){
	      	$(".home_boxed").addClass("bg3");
	      	$(".home_boxed").removeClass("bg2 bg1 bg4");
	    	});
	    	$(".bg4").on('click', function(){
	      	$(".home_boxed").addClass("bg4");
	      	$(".home_boxed").removeClass("bg2 bg3 bg1");
	    	});

	    	$('#styleOptions').styleSwitcher({
	        hasPreview: true,
	        fullPath: 'css/custom/',
	         	cookie: {
	          	expires: 30,
	          	isManagingLoad: true
	      		}
	    	});

	  	};
	}





	/*	=========================================================================
	When document is Scrollig, do
	========================================================================== */

	jQuery(document).on('ready', function () {
		(function ($) {
			// add your functions
			swithcerMenu ();
			selectMenu ();
			doughnutChartBox();
			galleryMasonaryLayout();
			priceFilter ();
			cartTouchSpin();
		})(jQuery);
	});



	/* ==========================================================================
   When document is Scrollig, do
   ========================================================================== */
	
	$(window).on('scroll', function() {
		stickyHeader ();
		factCounter();
		areaChart();
	});

	
	
	/* ==========================================================================
   When document is loaded, do
   ========================================================================== */
	
	$(window).on('load', function() {
		handlePreloader();
		languageSwitcher();
		chartBox();
		chartBoxTwo();
	});

	

})(window.jQuery);