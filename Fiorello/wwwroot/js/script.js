$(document).ready(function () {

    // HEADER

    $(document).on('click', '#search', function () {
        $(this).next().toggle();
    })

    $(document).on('click', '#mobile-navbar-close', function () {
        $(this).parent().removeClass("active");

    })
    $(document).on('click', '#mobile-navbar-show', function () {
        $('.mobile-navbar').addClass("active");

    })

    $(document).on('click', '.mobile-navbar ul li a', function () {
        if ($(this).children('i').hasClass('fa-caret-right')) {
            $(this).children('i').removeClass('fa-caret-right').addClass('fa-sort-down')
        }
        else {
            $(this).children('i').removeClass('fa-sort-down').addClass('fa-caret-right')
        }
        $(this).parent().next().slideToggle();
    })

    // SLIDER

    $(document).ready(function () {
        $(".slider").owlCarousel(
            {
                items: 1,
                loop: true,
                autoplay: true
            }
        );
    });

    // PRODUCT

    $(document).on('click', '.categories', function (e) {
        e.preventDefault();
        $(this).next().next().slideToggle();
    })

    $(document).on('click', '.category li a', function (e) {
        e.preventDefault();
        let category = $(this).attr('data-id');
        let products = $('.product-item');

        products.each(function () {
            if (category == $(this).attr('data-id')) {
                $(this).parent().fadeIn();
            }
            else {
                $(this).parent().hide();
            }
        })
        if (category == 'all') {
            products.parent().fadeIn();
        }
    })

    // ACCORDION 

    $(document).on('click', '.question', function () {
        $(this).siblings('.question').children('i').removeClass('fa-minus').addClass('fa-plus');
        $(this).siblings('.answer').not($(this).next()).slideUp();
        $(this).children('i').toggleClass('fa-plus').toggleClass('fa-minus');
        $(this).next().slideToggle();
        $(this).siblings('.active').removeClass('active');
        $(this).toggleClass('active');
    })

    // TAB

    $(document).on('click', 'ul li', function () {
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        let dataId = $(this).attr('data-id');
        $(this).parent().next().children('p.active').removeClass('active');

        $(this).parent().next().children('p').each(function () {
            if (dataId == $(this).attr('data-id')) {
                $(this).addClass('active')
            }
        })
    })

    $(document).on('click', '.tab4 ul li', function () {
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        let dataId = $(this).attr('data-id');
        $(this).parent().parent().next().children().children('p.active').removeClass('active');

        $(this).parent().parent().next().children().children('p').each(function () {
            if (dataId == $(this).attr('data-id')) {
                $(this).addClass('active')
            }
        })
    })

    // INSTAGRAM

    $(document).ready(function () {
        $(".instagram").owlCarousel(
            {
                items: 4,
                loop: true,
                autoplay: true,
                responsive: {
                    0: {
                        items: 1
                    },
                    576: {
                        items: 2
                    },
                    768: {
                        items: 3
                    },
                    992: {
                        items: 4
                    }
                }
            }
        );
    });

    $(document).ready(function () {
        $(".say").owlCarousel(
            {
                items: 1,
                loop: true,
                autoplay: true
            }
        );
    });




    // WITHOUT REFRESH (AJAX)

    if ($("tbody").children().length == 0) {
        $("table").addClass("d-none");
        $(".grand-total").addClass("d-none");
        $(".alert-warning").removeClass("d-none");
    }

    // ADD TO CART

    $(document).ready(function () {
        $(".add-to-cart").click(function () {
            let id = $(this).parent().parent().attr("data-id");

            $.ajax({
                type: "POST",
                url: `home/add/${id}`
            });

            Swal.fire(
                'Done!',
                `${$(this).parent().prev().first().text()} has been added to the cart`,
                'success'
            )
        });
    });


    // DELETE FROM CART

    $(document).ready(function () {
        $(".delete").click(function () {
            let id = $(this).parent().parent().attr("data-id");

            $.ajax({
                type: "POST",
                url: `cart/delete/${id}`
            });

            Swal.fire(
                'Done!',
                `${$(this).parent().parent().children().eq(1).text()} has been removed from the cart`,
                'success'
            )

            $(this).parent().parent().remove();

            if ($("tbody").children().length == 0) {
                $("table").addClass("d-none");
                $(".grand-total").addClass("d-none");
                $(".alert-warning").removeClass("d-none");
            }

            else {
                let grandTotal = 0;

                for (var value of $("tbody").children()) {
                    grandTotal += parseFloat($(value).children().eq(4).children().eq(1).text());
                }

                $(".grand-total").text(`Grand Total: $ ${grandTotal}`);
            }
        });
    });


    // INCREASE PRODUCT COUNT

    $(document).ready(function () {
        $(".plus").click(function() {
            let id = $(this).parent().parent().attr("data-id");

            $.ajax({
                type: "POST",
                url: `cart/increasecount/${id}`
            });

            let currentCount = parseInt($(this).prev().text());

            currentCount++;

            $(this).prev().text(currentCount);


            let price = parseFloat($(this).parent().prev().children().eq(1).text());
            $(this).parent().next().children().eq(1).text(price * currentCount);


            let grandTotal = 0;

            for (var value of $("tbody").children()) {
                grandTotal += parseFloat($(value).children().eq(4).children().eq(1).text());
            }

            $(".grand-total").text(`Grand Total: $ ${grandTotal}`);
        })
    });


    // DECREASE PRODUCT COUNT

    $(document).ready(function () {
        $(".minus").click(function () {
            let id = $(this).parent().parent().attr("data-id");

            $.ajax({
                type: "POST",
                url: `cart/decreasecount/${id}`
            });

            let currentCount = parseInt($(this).next().text());

            if (currentCount > 1) {
                currentCount--;

                $(this).next().text(currentCount);


                let price = parseFloat($(this).parent().prev().children().eq(1).text());
                $(this).parent().next().children().eq(1).text(price * currentCount);


                let grandTotal = 0;

                for (var value of $("tbody").children()) {
                    grandTotal += parseFloat($(value).children().eq(4).children().eq(1).text());
                }

                $(".grand-total").text(`Grand Total: $ ${grandTotal}`);
            };
        })
    });
});