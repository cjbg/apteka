$(function () {
    $('.vmenu-section').click(function () {
        var current = $(this).next();
        var old = $(this).parent("div").find(".active");

        if (current.is(':visible'))
            return;

        old.slideToggle(800);
        old.attr('class', 'inactive');

        current.stop().slideToggle(800);
        current.attr('class', 'active');

        $(this).stop().animate({
            paddingLeft: "30px"
        });

        old.prev().stop().animate({
            paddingLeft: "10px"
        });
    });
});
