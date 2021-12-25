const ctx = document.getElementById('myChart').getContext('2d');
const myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['1', '10', '20', '30', '40', '50', '60', '70', '100', '200', '300'],
        datasets: [{
            label: 'Потери теплоты излучения',
            data: [17754, 177544, 355088, 532632, 710177, 887721, 1065265, 1242810, 1775442, 3550885, 5326328],
            borderColor: 'rgb(75, 192, 192)'
        }]
    },
    options: {
        scales: {
            x: {
                display: true,
                title: {
                    display: true,
                    text: 'Температура в печи (tпеч), °С'
                }
            },
            y: {
                display: true,
                title: {
                    display: true,
                    text: 'Потери теплоты излучения (Qл), Дж'
                }
            }
        }
    }
    
});

