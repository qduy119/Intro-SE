import ReactApexChart from "react-apexcharts";

const donutChartOptions = {
    chart: {
        type: "donut",
    },
    labels: ["Food 1", "Food 2", "Food 3", "Food 4", "Others"],
    legend: {
        position: "bottom",
    },
};

export default function TopSalesFoodChart() {
    const series = [64, 55, 41, 37, 25];
    return (
        <div id="chart">
            <ReactApexChart
                options={donutChartOptions}
                series={series}
                type="donut"
            />
        </div>
    );
}
