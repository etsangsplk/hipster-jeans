FROM nginx:latest

# Copy custom nginx config
COPY operations/config/nginx.conf /etc/nginx/nginx.conf

# Install essential tools
RUN apt-get -qq update && \
    apt-get -qq install apt-transport-https && \
    apt-get -qq install build-essential && \
    apt-get -qq install git

# install nvm
RUN apt-get -qq install curl && \
    curl -o- https://raw.githubusercontent.com/creationix/nvm/v0.33.1/install.sh | bash

# install yarn
RUN curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add - && \
    echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list && \
    apt-get update && apt-get install yarn

ENV NVM_DIR /home/node/.nvm
ENV NODE_VERSION 7.6.0

# setup nvm
RUN . ~/.nvm/nvm.sh && \
    nvm install $NODE_VERSION && \
    nvm alias default $NODE_VERSION && \
    nvm use default

# add node and npm to path so the commands are available
ENV NODE_PATH $NVM_DIR/v$NODE_VERSION/lib/node_modules
ENV PATH $NVM_DIR/versions/node/v$NODE_VERSION/bin:$PATH

ADD js/ui .
RUN yarn install

WORKDIR node_modules/folktale
RUN npm install  && \
    make compile
WORKDIR  ../../
RUN yarn run web:build

RUN mkdir www && \
    cp app/web/index.html www && \
    cp -r app/web/dist/app.bundle.js www && \
    cp -r app/web/dist/vendor.bundle.js www

ENTRYPOINT ["nginx"]
CMD ["-g", "daemon off;"]
