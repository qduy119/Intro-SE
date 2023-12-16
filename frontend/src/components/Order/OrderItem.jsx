import { IconButton, Tooltip } from "@mui/material";
import CancelIcon from "@mui/icons-material/Cancel";
import KeyboardReturnIcon from "@mui/icons-material/KeyboardReturn";
import PaymentsIcon from "@mui/icons-material/Payments";
import Status from "../Status/Status";
import { formatDate } from "../../utils";
import { useGetPaymentQuery } from "../../services/payment";

export default function OrderItem({
    item,
    t,
    onReturnTable,
    onCancelOrder,
    onPayOrder,
}) {
    const { data: payment } = useGetPaymentQuery({ orderId: item.id });

    return (
        <>
            <tr className="border-b border-primary-dark">
                <td className="whitespace-nowrap px-6 py-4 font-medium">{t}</td>
                <td className="whitespace-nowrap px-6 py-4">{item.id}</td>
                <td className="whitespace-nowrap px-6 py-4">
                    {formatDate(item.orderDate)}
                </td>
                <td className="whitespace-nowrap px-6 py-4">
                    {payment?.data[0]?.paymentMethod}
                </td>
                <td className="whitespace-nowrap px-6 py-4">{item.total} $</td>
                <td className="whitespace-nowrap px-6 py-4">
                    {item.seatNumber}
                </td>
                <td className="whitespace-nowrap px-6 py-4">
                    <div className="flex items-center justify-center">
                        <Status status={item.status} />
                    </div>
                </td>
                <td className="whitespace-nowrap px-6 py-4">
                    <div className="flex gap-2 items-center justify-center">
                        {item.status === "Pending" ? (
                            <>
                                <Tooltip title="Pay Now">
                                    <IconButton
                                        onClick={() =>
                                            onPayOrder({
                                                order: item,
                                                payment: payment?.data[0],
                                            })
                                        }
                                    >
                                        <PaymentsIcon />
                                    </IconButton>
                                </Tooltip>
                                <Tooltip title="Cancel Order">
                                    <IconButton
                                        onClick={() =>
                                            onCancelOrder({
                                                order: item,
                                                payment: payment?.data[0],
                                            })
                                        }
                                    >
                                        <CancelIcon />
                                    </IconButton>
                                </Tooltip>
                            </>
                        ) : item.status === "Success" ? (
                            <Tooltip title="Return Table">
                                <IconButton
                                    onClick={() =>
                                        onReturnTable(item.seatNumber)
                                    }
                                >
                                    <KeyboardReturnIcon />
                                </IconButton>
                            </Tooltip>
                        ) : null}
                    </div>
                </td>
            </tr>
        </>
    );
}
