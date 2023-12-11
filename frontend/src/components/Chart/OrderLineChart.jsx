import { useState, useEffect } from "react";

// material-ui
import { useTheme } from "@mui/material/styles";

// third-party
import ReactApexChart from "react-apexcharts";

// chart options
const lineChartOptions = {
    chart: {
        height: 450,
        type: "line",
        toolbar: {
            show: false,
        },
    },
    dataLabels: {
        enabled: false,
    },
    stroke: {
        curve: "smooth",
        width: 2,
    },
    grid: {
        strokeDashArray: 0,
    },
};

// ==============================|| INCOME AREA CHART ||============================== //

const OrderLineChart = ({ slot }) => {
    const theme = useTheme();

    const { primary, secondary } = theme.palette.text;
    const line = theme.palette.divider;

    const [options, setOptions] = useState(lineChartOptions);

    useEffect(() => {
        setOptions((prevState) => ({
            ...prevState,
            colors: [theme.palette.primary.main, theme.palette.primary[700]],
            xaxis: {
                categories:
                    slot === "month"
                        ? [
                              "Jan",
                              "Feb",
                              "Mar",
                              "Apr",
                              "May",
                              "Jun",
                              "Jul",
                              "Aug",
                              "Sep",
                              "Oct",
                              "Nov",
                              "Dec",
                          ]
                        : ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
                labels: {
                    style: {
                        colors: [
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                            secondary,
                        ],
                    },
                },
                axisBorder: {
                    show: true,
                    color: line,
                },
                tickAmount: slot === "month" ? 11 : 7,
            },
            yaxis: {
                labels: {
                    style: {
                        colors: [secondary],
                    },
                },
            },
            grid: {
                borderColor: line,
            },
            tooltip: {
                theme: "light",
            },
        }));
    }, [primary, secondary, line, theme, slot]);

    const [series, setSeries] = useState([
        {
            name: "Total Orders",
            data: [0, 86, 28, 115, 48, 210, 136],
        },
    ]);

    useEffect(() => {
        setSeries([
            {
                name: "Total Orders",
                data:
                    slot === "month"
                        ? [76, 85, 101, 98, 87, 105, 91, 114, 94, 86, 115, 35]
                        : [31, 40, 28, 51, 42, 109, 100],
            },
        ]);
    }, [slot]);

    return (
        <ReactApexChart
            options={options}
            series={series}
            type="line"
            height={450}
        />
    );
};

export default OrderLineChart;
