export const formatPrice = (price) => {
    return Number(price).toFixed(2);
};

export const isAvailableSeat = (seats, seatNumber) => {
    const allSeats = seats?.reduce((result, item) => {
        result.push(item.seatNumber);
        return result;
    }, []);
    return !allSeats?.includes(seatNumber);
};

export const formatDate = (date) => {
    return new Date(date).toLocaleString("vi-VN");
};
