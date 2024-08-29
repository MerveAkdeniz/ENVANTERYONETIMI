
function submitForm(event) {
    event.preventDefault(); // Formun varsayılan gönderimini engeller

    var form = document.querySelector('.filterForm');
    var selectedColumns = Array.from(form.querySelectorAll('input[type="checkbox"]:checked'))
        .map(cb => cb.value); // Kolon isimlerini alır

    // Debug için seçilen kolonları konsola yazdıralım
    console.log("Seçilen Kolonlar:", selectedColumns);


    //burası ajax ile yapılmıştır. Sunucudan dinamik olarak tablo verisi almak için AJAX kullanıyoruz.
    $.post('/InventoryViewModel/GetTable', { selectedColumns: selectedColumns })
        .done(function (data) {
            var tableContainer = document.querySelector('#tableContainer');
            tableContainer.innerHTML = data;
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Hata oluştu: ", textStatus, errorThrown);
        });
}
