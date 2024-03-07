function[W]  = rozniczkowanietaylor(x,y,h)
  tab = zeros(size(x,2),size(x,2)+1);
  tab(:,1)=x;
  tab(:,2)=y;
  fx = 0;
  for j = 3:size(x,2)+1;
    for i = size(x,2)-(j-2):-1:1;
      tab(i,j)=tab(i+1,j-1)-tab(i,j-1);
    endfor
    fx+=1/(j-2)*tab(size(x,2)+2-j,j);
  endfor
  W=fx*1/h;
  endfunction
