$(document).ready(function () {
    $("#tshirttype").change(function () {
        $("img[name=tshirtview]").attr("src", $(this).val());
        $("#flipback").attr('data-original-title', 'Show Back View');
    });
  
var valueSelect = $("#tshirttype").val();
$("#tshirttype").change(function () {
    valueSelect = $(this).val();
});
$('#clear-selected').click(
    function () {
       
        canvas.deactivateAll().renderAll();
        
    });
$('#save-selected').click(
    function () {
        onSelectedCleared();
        canvas.deactivateAll().renderAll();
    });
$('#flipback').click(
    function () {
        if (valueSelect === "../img/crew_front.png") {
            if ($(this).attr("data-original-title") == "Show Back View") {
                $(this).attr('data-original-title', 'Show Front View');
               
                $("#tshirtFacing").attr("src", "../img/crew_back.png");
                a = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(b);
                    canvas.loadFromJSON(b);
                }
                catch (e) { }

            } else {
                $(this).attr('data-original-title', 'Show Back View');
               
                $("#tshirtFacing").attr("src", "../img/crew_front.png");
                b = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(a);
                    canvas.loadFromJSON(a);
                }
                catch (e) { }
            }
        }

        else if (valueSelect === "../img/mens_longsleeve_front.png") {
            if ($(this).attr("data-original-title") == "Show Back View") {
                $(this).attr('data-original-title', 'Show Front View');
                $("#tshirtFacing").attr("src", "../img/mens_longsleeve_back.png");
                a = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(b);
                    canvas.loadFromJSON(b);
                }
                catch (e) { }

            } else {
                $(this).attr('data-original-title', 'Show Back View');
                $("#tshirtFacing").attr("src", "../img/mens_longsleeve_front.png");
                b = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(a);
                    canvas.loadFromJSON(a);
                }
                catch (e) { }
            }
        }
        else if (valueSelect === "../img/mens_tank_front.png") {
            if ($(this).attr("data-original-title") == "Show Back View") {
                $(this).attr('data-original-title', 'Show Front View');
                $("#tshirtFacing").attr("src", "../img/mens_tank_back.png");
                a = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(b);
                    canvas.loadFromJSON(b);
                }
                catch (e) { }

            } else {
                $(this).attr('data-original-title', 'Show Back View');
                $("#tshirtFacing").attr("src", "../img/mens_tank_front.png");
                b = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(a);
                    canvas.loadFromJSON(a);
                }
                catch (e) { }
            }
        }
        else if (valueSelect === "../img/mens_hoodie_front.png") {
            if ($(this).attr("data-original-title") == "Show Back View") {
                $(this).attr('data-original-title', 'Show Front View');
                $("#tshirtFacing").attr("src", "../img/mens_hoodie_back.png");
                a = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(b);
                    canvas.loadFromJSON(b);
                }
                catch (e) { }

            } else {
                $(this).attr('data-original-title', 'Show Back View');
                $("#tshirtFacing").attr("src", "../img/mens_hoodie_front.png");
                b = JSON.stringify(canvas);
                canvas.clear();
                try {
                    var json = JSON.parse(a);
                    canvas.loadFromJSON(a);
                }
                catch (e) { }
            }
        }
        onSelectedCleared();
        canvas.renderAll();
        setTimeout(function () {
            canvas.calcOffset();
        }, 200);
        
     
    });	

var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-35639689-1']);
_gaq.push(['_trackPageview']);

//(function () {
//    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
//    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
//    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
//})();
});