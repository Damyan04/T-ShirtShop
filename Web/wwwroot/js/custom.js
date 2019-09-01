jQuery(document).ready(function($) {
    window.onscroll = function () { scrollFunction() };

	
    function scrollFunction() {
        if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
            document.getElementById("myBtn").style.display = "block";
        } else {
            document.getElementById("myBtn").style.display = "none";
        }
    }
    
        $('.scrollup').click(function () {
            $("html, body").animate({ scrollTop: 0 }, 1000);
            
            return false;
        });
    
    
   
		$('.accordion').on('show', function (e) {
		
			$(e.target).prev('.accordion-heading').find('.accordion-toggle').addClass('active');
			$(e.target).prev('.accordion-heading').find('.accordion-toggle i').removeClass('icon-plus');
			$(e.target).prev('.accordion-heading').find('.accordion-toggle i').addClass('icon-minus');
		});
		
		$('.accordion').on('hide', function (e) {
			$(this).find('.accordion-toggle').not($(e.target)).removeClass('active');
			$(this).find('.accordion-toggle i').not($(e.target)).removeClass('icon-minus');
			$(this).find('.accordion-toggle i').not($(e.target)).addClass('icon-plus');
		});	

	$('.navigation').onePageNav({
		begin: function() {
			console.log('start');
		},
		end: function() {
			console.log('stop');
		},
			scrollOffset: 0		
	});
	
	// prettyPhoto
	$("a[data-pretty^='prettyPhoto']").prettyPhoto();		

    // Localscrolling 
	$('#menu-main, .brand').localScroll();
	
	$('#menu-main li a').click(function(){
		var links = $('#menu-main li a');
		links.removeClass('selected');
		$(this).addClass('selected');
	});

    var iOS = false,
        p = navigator.platform;

    if (p === 'iPad' || p === 'iPhone' || p === 'iPod') {
        iOS = true;
    }	
	
    if (iOS === false) {

        $('.flyIn').bind('inview', function (event, visible) {
            if (visible === true) {
                $(this).addClass('animated fadeInUp');
            }
        });

        $('.flyLeft').bind('inview', function (event, visible) {
            if (visible === true) {
                $(this).addClass('animated fadeInLeftBig');
            }
        });

        $('.flyRight').bind('inview', function (event, visible) {
            if (visible === true) {
                $(this).addClass('animated fadeInRightBig');
            }
        });

    }
	
	// add animation on hover
		$(".service-box").hover(
			function () {
			$(this).find('img').addClass("animated pulse");
			$(this).find('h2').addClass("animated fadeInUp");
			},
			function () {
			$(this).find('img').removeClass("animated pulse");
			$(this).find('h2').removeClass("animated fadeInUp");
			}
		);
		
	
	// cache container
	var $container = $('#product-item-wrap');
	//$.browser.safari = ($.browser.webkit && !(/chrome/.test(navigator.userAgent.toLowerCase())));	
	
	//if($.browser.safari){ 	
	//// initialize isotope
	//$container.isotope({
	//	animationEngine : 'jquery',
	//	animationOptions: {
	//		duration: 200,
	//		queue: false
	//	},
	//	layoutMode: 'fitRows'
	//});
	//} else {	
	$container.isotope({
		animationEngine : 'best-available',
		animationOptions: {
			duration: 200,
			queue: false
		},
		layoutMode: 'fitRows'
	});	
	
	$(window).resize(function() {
		$container.isotope('layout');
	});
	
	// filter items when filter link is clicked
	$('#filters a').click(function(){
		$('#filters a').removeClass('active');
		$(this).addClass('active');
        var selector = $(this).attr('data-filter');
        
        selector = selector.toLowerCase();
        selector = selector.split(" ");
      
     
        if (selector.length > 1) {
            var selectors = ""
            for (var i = 0; i <= selector.length-1; i++) {
                if (i > 0) {
                    selectors += '-' + selector[i];
                } else {
                    selectors += selector[i];
                }
            }
          
            $container.isotope({ filter: selectors });
        } else {
           
            $container.isotope({ filter: selector[0] });
        }
      
      //  selector = filterFns[selector] || selector;

		
		return false;
	});

	// flexslider main
	$('#main-flexslider').flexslider({						
		animation: "swing",
		direction: "vertical", 
		slideshow: true,
		slideshowSpeed: 3500,
		animationDuration: 1000,
		directionNav: true,
		prevText: '<i class="icon-angle-up icon-2x"></i>',       
		nextText: '<i class="icon-angle-down icon-2x active"></i>', 
		controlNav: false,
		smootheHeight:true,						
		useCSS: false
    });
   
});
   
	
	