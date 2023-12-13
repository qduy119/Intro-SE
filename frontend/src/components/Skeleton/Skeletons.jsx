import { Box, Grid, Skeleton } from "@mui/material";

export default function Skeletons() {
    return (
        <Grid
            container
            wrap="wrap"
            justifyContent="center"
            alignItems="center"
            columnGap={1}
            rowGap={3}
        >
            {Array.from({ length: 10 }, (index) => index).map((index) => (
                <Box key={index} sx={{ width: 200 }}>
                    <Skeleton variant="rectangular" width={200} height={300} />
                    <Box sx={{ pt: 0.5 }}>
                        <Skeleton />
                        <Skeleton width="60%" />
                        <Skeleton width="80%" />
                    </Box>
                </Box>
            ))}
        </Grid>
    );
}
