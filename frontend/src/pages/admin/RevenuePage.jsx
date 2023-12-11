import {
    Box,
    Grid,
    List,
    ListItemButton,
    ListItemText,
    MenuItem,
    Stack,
    TextField,
    Typography,
} from "@mui/material";

// project import
import ReportAreaChart from "../../components/Chart/ReportAreaChart";
import SalesColumnChart from "../../components/Chart/SalesColumnChart";
import WeeklyBarChart from "../../components/Chart/WeeklyBarChart";
import MainCard from "../../components/Card/MainCard";
import UserMask from "../../components/User/UserMask";
import { useState } from "react";

const status = [
    {
        value: "today",
        label: "Today",
    },
    {
        value: "month",
        label: "This Month",
    },
    {
        value: "year",
        label: "This Year",
    },
];

export default function RevenuePage() {
    const [value, setValue] = useState("today");

    return (
        <>
            <div className="flex justify-end pb-2 border-b-2 border-primary-light">
                <UserMask />
            </div>
            <div className="p-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">
                    REVENUE
                </h1>
                <div className="bg-primary-light w-[135px] h-[3px] rounded-[4px] mb-5" />
                <Grid container rowSpacing={4.5} columnSpacing={2.75}>
                    {/* row 1 */}
                    <Grid item xs={12}>
                        <Grid
                            container
                            alignItems="center"
                            justifyContent="space-between"
                        >
                            <Grid item>
                                <Typography variant="h5">
                                    Sales Report
                                </Typography>
                            </Grid>
                            <Grid item>
                                <TextField
                                    id="standard-select-currency"
                                    size="small"
                                    select
                                    value={value}
                                    onChange={(e) => setValue(e.target.value)}
                                    sx={{
                                        "& .MuiInputBase-input": {
                                            py: 0.5,
                                            fontSize: "0.875rem",
                                        },
                                    }}
                                >
                                    {status.map((option) => (
                                        <MenuItem
                                            key={option.value}
                                            value={option.value}
                                        >
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </Grid>
                        </Grid>
                        <MainCard sx={{ mt: 1.75 }}>
                            <Stack spacing={1.5} sx={{ mb: -12 }}>
                                <Typography variant="h6" color="secondary">
                                    Net Profit
                                </Typography>
                                <Typography variant="h4">$1560</Typography>
                            </Stack>
                            <SalesColumnChart />
                        </MainCard>
                    </Grid>
                    <Grid item xs={12} md={6} lg={6}>
                        <Grid
                            container
                            alignItems="center"
                            justifyContent="space-between"
                        >
                            <Grid item>
                                <Typography variant="h5">
                                    Income Overview
                                </Typography>
                            </Grid>
                            <Grid item />
                        </Grid>
                        <MainCard sx={{ mt: 2 }} content={false}>
                            <Box sx={{ p: 3, pb: 0 }}>
                                <Stack spacing={2}>
                                    <Typography
                                        variant="h6"
                                        color="textSecondary"
                                    >
                                        This Week Statistics
                                    </Typography>
                                    <Typography variant="h3">$7,650</Typography>
                                </Stack>
                            </Box>
                            <WeeklyBarChart />
                        </MainCard>
                    </Grid>
                    <Grid item xs={12} md={6} lg={6}>
                        <Grid
                            container
                            alignItems="center"
                            justifyContent="space-between"
                        >
                            <Grid item>
                                <Typography variant="h5">
                                    Analytics Report
                                </Typography>
                            </Grid>
                            <Grid item />
                        </Grid>
                        <MainCard sx={{ mt: 2 }} content={false}>
                            <List
                                sx={{
                                    p: 0,
                                    "& .MuiListItemButton-root": { py: 2 },
                                }}
                            >
                                <ListItemButton divider>
                                    <ListItemText primary="Company Finance Growth" />
                                    <Typography variant="h5">
                                        +45.14%
                                    </Typography>
                                </ListItemButton>
                                <ListItemButton divider>
                                    <ListItemText primary="Company Expenses Ratio" />
                                    <Typography variant="h5">0.58%</Typography>
                                </ListItemButton>
                                <ListItemButton>
                                    <ListItemText primary="Business Risk Cases" />
                                    <Typography variant="h5">Low</Typography>
                                </ListItemButton>
                            </List>
                            <ReportAreaChart />
                        </MainCard>
                    </Grid>
                </Grid>
            </div>
        </>
    );
}
