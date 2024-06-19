import type { EntityDto } from '@abp/ng.core';
import type { OrderStatus } from '../../orders/order-status.enum';
import type { OrderStatus } from '../../orders/models';

export interface CustomerDto extends EntityDto<string> {
  name?: string;
  email?: string;
}

export interface OrderAddressDto {
  description?: string;
  street: string;
  city: string;
  country: string;
  zipCode: string;
}

export interface OrderCreateDto {
  address: OrderAddressDto;
}

export interface OrderDto extends EntityDto<string> {
  orderNo: number;
  status: OrderStatus;
  customer: CustomerDto;
  address: OrderAddressDto;
}
