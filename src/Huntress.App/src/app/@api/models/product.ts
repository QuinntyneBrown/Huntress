import { ProductImage } from "./product-image";

export type Product = {
    productId: string,
    name: string,
    description: string,
    productImages: ProductImage[]
    quantityInStock: number,
    onReOrder: boolean,
    onPreOrder: boolean,
    inventoryCount: number;
};
