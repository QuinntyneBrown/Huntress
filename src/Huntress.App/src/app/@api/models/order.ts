import { OrderItem } from "./order-item";
import { OrderStatus } from "./order-status";

export type Order = {
    orderId: string,
    customerId: string,
    orderItems: OrderItem[],
    status: OrderStatus
};
