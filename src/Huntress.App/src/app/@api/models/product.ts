import { ProductImage } from "./product-image";

export type Product = {
    productId: string,
    name: string,
    description: string,
    productImages: ProductImage[]
};
