export const formatCurrencyToBrl = (value?: number): string => {
  if (!value) return '';

  return value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
};
