$(document).ready(function () {
    $('.category-button').on('click', function () {
        var selectedCategory = $(this).data('category');
        var url = '/ProductDetail/FilterByCategory'; // Doğru URL'yi burada tanımlayın

        $.ajax({
            url: url,
            type: 'GET',
            data: { category: selectedCategory },
            success: function (data) {
                $('#product-list').html(data);
            },
            error: function (xhr, status, error) {
                console.error('AJAX Error:', status, error);
            }
        });
    });
});

