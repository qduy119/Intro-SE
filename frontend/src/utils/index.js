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

export const isSeatReturned = (seats, { orderId, seatNumber }) => {
    const found = seats?.some(
        (seat) => seat.orderId === orderId && seat.seatNumber === seatNumber
    );
    return !found;
};

export const formatDate = (date) => {
    return new Date(date).toLocaleString("vi-VN");
};

export const formatDateOfBirth = (dateString) => {
    if (!dateString) return "";
    const date = new Date(dateString);
    const formattedDate = date.toISOString().split('T')[0];
    return formattedDate;
}

export const getPaymentByOrderId = (payments, orderId) => {
    return payments?.find((payment) => payment.orderId === orderId);
};

export const getUserByOrder = (users, userIdInOrder) => {
    return users?.find((user) => user.id === userIdInOrder);
};

export const getRevenue = (orders, { slot }) => {
    const hash =
        slot === "week"
            ? ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"]
            : [
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
              ];
    const initialRevenue =
        slot === "week" ? new Array(7).fill(0) : new Array(12).fill(0);
    const revenue = orders?.reduce((totalRevenue, order) => {
        const dayIn =
            slot === "week"
                ? new Date(order.orderDate).getDay()
                : new Date(order.orderDate).getMonth();
        if (order.status === "Success") {
            totalRevenue[dayIn] += order.total;
        }
        return totalRevenue;
    }, initialRevenue);
    const result = revenue?.map((amount, key) => {
        return { [hash[key]]: amount };
    });
    return result;
};

export const getOrder = (orders, { slot }) => {
    const hash =
        slot === "week"
            ? ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"]
            : [
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
              ];
    const initialRevenue =
        slot === "week" ? new Array(7).fill(0) : new Array(12).fill(0);
    const total = orders?.reduce((totalRevenue, order) => {
        const dayIn =
            slot === "week"
                ? new Date(order.orderDate).getDay()
                : new Date(order.orderDate).getMonth();
        if (order.status === "Success") {
            totalRevenue[dayIn] += 1;
        }
        return totalRevenue;
    }, initialRevenue);
    const result = total?.map((amount, key) => {
        return { [hash[key]]: amount };
    });
    return result;
};
